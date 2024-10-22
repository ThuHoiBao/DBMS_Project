
use EnglishCourse_DataBase
go

---0 Lay mot khoa hoc co ma khoa hoc

CREATE PROCEDURE procedureCourse
    @idCourse NVARCHAR(10)
AS
BEGIN
    SELECT 
        id, 
        name,
		description,
		timeLession,
		price,
		totalLession,
		totalStudent
    FROM 
        Course
    WHERE 
        id = @idCourse;
END;
EXEC procedureCourse @idCourse = 'C001';
--- 1 Pro xem Danh sách các khóa học mà giảng viên dạy
CREATE PROCEDURE procedureCourseListByTeacher
    @idTeacher INT
AS
BEGIN
    SELECT 
        id, 
        name
		
    FROM 
        Course
    WHERE 
        idTeacher = @idTeacher;
END;


EXEC procedureCourseListByTeacher @idTeacher = 7;
--- 2 Giảng viên tìm kiếm khóa học mình dạy
CREATE FUNCTION FuntionSearchCourseByIdOrName
(
    @idTeacher INT,              
    @searchValue NVARCHAR(50)     
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        id, 
        name
		
    FROM 
        Course
    WHERE 
        idTeacher = @idTeacher 
        AND (
            @searchValue IS NULL OR @searchValue = '' 
            OR CONCAT(CAST(id AS NVARCHAR(50)), ' ', name) LIKE '%' + @searchValue + '%'
        )
);
SELECT * 
FROM FuntionSearchCourseByIdOrName(7, '1');


--- 3 Pro xem danh sach tai lieu cua khoa hoc

CREATE PROCEDURE procedureDocumentsByCourse
(
    @idCourse NVARCHAR(10)  -- Tham số đầu vào là id của khóa học
)
AS
BEGIN
    SELECT    
		id,
        name,     
        Date,     
        content    
    FROM 
        Document
    WHERE 
        idCourse = @idCourse;  -- Lọc tài liệu theo idCourse
END;

EXEC procedureDocumentsByCourse @idCourse = 'C001';
---5 Lay mot tai lieu  co ma tai lieu
CREATE PROCEDURE procedureDocument
    @id int
AS
BEGIN
    SELECT 
        id, 
        name,
		content
    FROM 
        Document
    WHERE 
        id = @id;
END;
EXEC procedureDocument @id = 8;
--- 4 Pro them mot tai lieu vao mot khoa hoc

CREATE PROCEDURE procedureInsertDocument
(
    @idCourse NVARCHAR(10),  
    @name NVARCHAR(100),     
    @content NVARCHAR(MAX)   
)
AS
BEGIN
    -- Chèn một tài liệu mới vào bảng Document, sử dụng GETDATE() cho ngày hiện tại
    INSERT INTO Document (idCourse, name, Date, content)
    VALUES (@idCourse, @name, GETDATE(), @content);
    
END;

EXEC procedureInsertDocument
    @idCourse = 'C002', 
    @name = ' re ', 
    @content = 'Chào mấy con gà :))';

--- 5 Pro sua mot tai lieu vao mot khoa hoc
CREATE PROCEDURE  procedureUpdateDocument
(
    @id INT,              
    @idCourse NVARCHAR(10),
    @name NVARCHAR(100),   
    @content NVARCHAR(MAX) 
)
AS
BEGIN
 
    UPDATE Document
    SET 
        idCourse = @idCourse,  
        name = @name,         
        Date = GETDATE(),      
        content = @content     
    WHERE 
        id = @id;             
    
END;

EXEC  procedureUpdateDocument
    @id = 3, 
    @idCourse = 'C001', 
    @name = 'Updated Chapter 1', 
    @content = 'Ngu bỏ mẹ học ít thôi';

--- 6 Pro xoa mot tai lieu vao mot khoa hoc
CREATE PROCEDURE procedureDeleteDocument
(
    @id INT 
)
AS
BEGIN
    -- Xóa tài liệu dựa trên ID mà không kiểm tra tồn tại
    DELETE FROM Document
    WHERE id = @id;
END;

EXEC  procedureDeleteDocument @id = 5;  -- Xóa tài liệu có ID là 1

--- 7 Pro xem danh sach sinh vien mot khoa hoc

CREATE PROCEDURE procedureStudentsByCourse
(
    @idCourse NVARCHAR(10)  -- Tham số ID khóa học
)
AS
BEGIN
    SELECT 
        r.id,
        s.fullName,
        s.phoneNumber,
        r.status,
		s.avatar
    FROM 
        Register r
    JOIN 
        Student s ON r.idStudent = s.id
    WHERE 
        r.idCourse = @idCourse
    ORDER BY 
        r.status ASC;  -- Sắp xếp theo trạng thái tăng dần
END;

EXEC procedureStudentsByCourse @idCourse = 'C001';-- Thay 'C01' bằng ID khóa học bạn muốn
--- 7 Pro xem  mot sinh vien trong mot khoa hoc
CREATE PROCEDURE procedureStudent
(
    @id Int  -- Tham số ID khóa học
)
AS
BEGIN
    SELECT 
        r.id,
        s.fullName,
        s.phoneNumber,
        r.status,
		s.avatar,
		s.address,
		s.email
    FROM 
        Register r
    JOIN 
        Student s ON r.idStudent = s.id
    WHERE 
        r.id = @id
    ORDER BY 
        r.status ASC;  -- Sắp xếp theo trạng thái tăng dần
END;

EXEC procedureStudent @id = 4
--- 8 Pro xac nhan hoc sinh vao mot khoa hoc

CREATE PROCEDURE procedureUpdateStudentStatus
(
    @id INT,                   -- Tham số ID của bản ghi trong bảng Register
    @newStatus NVARCHAR(100)   
)
AS
BEGIN
    
    UPDATE Register
    SET status = @newStatus
    WHERE id = @id;            
END;


EXEC procedureUpdateStudentStatus @id = 11, @newStatus = '0';  -- Thay 1 bằng ID bản ghi và 'Confirmed' bằng trạng thái mới


--- 9 Pro xoa mot hoc sinh trong mot khoa hoc
CREATE PROCEDURE procedureRemoveStudentFromCourse
(
    @id INT                     -- Tham số ID của bản ghi trong bảng Register
)
AS
BEGIN
    -- Xóa sinh viên khỏi khóa học trong bảng Register dựa trên ID của bản ghi
    DELETE FROM Register
    WHERE id = @id;            
END;
EXEC procedureRemoveStudentFromCourse @id = 8;  -- Thay 1 bằng ID bản ghi thực tế

--- 10 tim kiem hoc sinh trong mot khoa hoc theo ten hoc sdt

CREATE FUNCTION funtionSearchStudentsByCourse
(
    @idCourse NVARCHAR(10),      -- Tham số ID khóa học
    @searchValue NVARCHAR(100)    -- Tham số tìm kiếm (có thể là tên hoặc số điện thoại)
)
RETURNS @StudentTable TABLE
(
    id INT,
    fullName NVARCHAR(100),
    phoneNumber VARCHAR(10),
    status NVARCHAR(100)
)
AS
BEGIN
    INSERT INTO @StudentTable
    SELECT 
        r.id,
        s.fullName,
        s.phoneNumber,
        r.status
    FROM 
        Register r
    JOIN 
        Student s ON r.idStudent = s.id
    WHERE 
        r.idCourse = @idCourse
        AND (@searchValue IS NULL OR @searchValue = '' OR 
             s.fullName LIKE '%' + @searchValue + '%' OR 
             s.phoneNumber LIKE '%' + @searchValue + '%')
    ORDER BY 
        r.status ASC;  -- Sắp xếp theo trạng thái tăng dần

    RETURN;  -- Trả về bảng kết quả
END;
SELECT * FROM funtionSearchStudentsByCourse('C001', 'g');  -- Thay 'C01' và 'John' bằng giá trị thực tế
---11 trigger kiem tra them hoac xoa document
CREATE TRIGGER triggerCheckDocument
ON Document
FOR INSERT,Update
AS
BEGIN
    -- Kiểm tra các bản ghi được thêm mới hoặc cập nhật
    IF EXISTS (
        SELECT 1
        FROM inserted
        WHERE (name IS NULL OR LTRIM(RTRIM(name)) = '') 
           OR (content IS NULL OR LTRIM(RTRIM(content)) = '')
    )
    BEGIN
        -- Nếu trường name hoặc content bị bỏ trống, hủy thao tác và đưa ra lỗi
        RAISERROR ('Trường name và content không được để trống.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;

