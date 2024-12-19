-- Create the database
CREATE DATABASE LegalCaseManagementSystem;
GO

/*USE LegalCaseManagementSystem;
GO*/

-- Create Users table
CREATE TABLE SystemUsers (
    UserID INT PRIMARY KEY, -- User ID
    FirstName NVARCHAR(50) NOT NULL, -- First Name
    MiddleName NVARCHAR(50) NOT NULL, -- Middle Name
    LastName NVARCHAR(50) NOT NULL, -- Last Name
    UserRole NVARCHAR(20) NOT NULL, -- User Role
    PhoneNumber NVARCHAR(15), -- Phone Number
    UserName NVarChar(200) not null,
    UserPassword NVARCHAR(255) NOT NULL, -- Password
    DateAdded DATE NOT NULL -- Date Added
);

-- Create Lawyers table
CREATE TABLE LegalLawyers (
    LawyerID INT PRIMARY KEY, -- Lawyer ID
    FirstName NVARCHAR(50) NOT NULL, -- First Name
    MiddleName NVARCHAR(50) NOT NULL, -- Middle Name
    LastName NVARCHAR(50) NOT NULL, -- Last Name
    Specialization NVARCHAR(50) NOT NULL, -- Specialization
    CaseCount INT DEFAULT 0, -- Number of Cases
    CourtID INT NOT NULL, -- Court ID (Foreign Key)
    PhoneNumber NVARCHAR(15), -- Phone Number
);

-- Create Court table
CREATE TABLE LegalCourts (
    CourtID INT PRIMARY KEY AUTO_INCREMENT, -- Court ID
    SessionDay NVARCHAR(20) NOT NULL, -- Session Day
    Judge1FirstName NVARCHAR(50) NOT NULL, -- Judge 1 First Name
    Judge1MiddleName NVARCHAR(50) NOT NULL, -- Judge 1 Middle Name
    Judge1LastName NVARCHAR(50) NOT NULL, -- Judge 1 Last Name
    Judge2FirstName NVARCHAR(50)NOT NULL, -- Judge 2 First Name
    Judge2MiddleName NVARCHAR(50)NOT NULL, -- Judge 2 Middle Name
    Judge2LastName NVARCHAR(50)NOT NULL, -- Judge 2 Last Name
    Judge3FirstName NVARCHAR(50)NOT NULL, -- Judge 3 First Name
    Judge3MiddleName NVARCHAR(50)NOT NULL, -- Judge 3 Middle Name
    Judge3LastName NVARCHAR(50)NOT NULL, -- Judge 3 Last Name
    ReserveJudgeFirstName NVARCHAR(50), -- Reserve Judge First Name
    ReserveJudgeMiddleName NVARCHAR(50), -- Reserve Judge Middle Name
    ReserveJudgeLastName NVARCHAR(50) -- Reserve Judge Last Name
);

-- Create Cases table
CREATE TABLE CourtCases (
    CaseID INT AUTO_INCREMENT PRIMARY KEY , -- Case ID
    DefendantName NVARCHAR(255) NOT NULL, -- Defendant Name
    CaseStatus NVARCHAR(10) CHECK (CaseStatus IN ('Ongoing', 'Closed')) NOT NULL, -- Case Status
    Charge NVARCHAR(255)NOT NULL, -- Charge
    CaseDate DATE NOT NULL, -- Case Date
    ProxyNumber INT, -- Proxy Number
    ProxyDate DATE, -- Proxy Date
    CourtID INT NOT NULL, -- Court ID (Foreign Key)
    LawyerID INT NOT NULL, -- Lawyer ID (Foreign Key)
    FOREIGN KEY (CourtID) REFERENCES LegalCourts(CourtID), -- Relationship with Court
    FOREIGN KEY (LawyerID) REFERENCES LegalLawyers(LawyerID), -- Relationship with Lawyers
);
GO