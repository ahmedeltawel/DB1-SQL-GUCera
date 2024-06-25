# GUCera - Educational Platform

GUCera is an educational website designed to facilitate various academic processes for students, instructors, and administrators. This platform uses SQL Server for database management and includes functionalities implemented in ASP.NET and C#.

## Table of Contents

- [Installation](#installation)
- [Database Schema](#database-schema)
- [Stored Procedures](#stored-procedures)
- [Functionalities](#functionalities)
  - [Admin Functionalities](#admin-functionalities)
  - [Instructor Functionalities](#instructor-functionalities)
  - [Student Functionalities](#student-functionalities)
- [Contributors](#contributors)

## Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/your-repository/GUCera.git
   ```

2. **Database Setup:**
   - Open SQL Server Management Studio (SSMS).
   - Execute the `GUCera.sql` file to create the database and all necessary tables and procedures.

3. **Backend and Frontend Setup:**
   - Open the solution file (`.sln`) in Visual Studio.
   - Restore the NuGet packages.
   - Build and run the project.

## Database Schema

The database schema consists of the following tables:

- Users
- Instructor
- UserMobileNumber
- Student
- Admin
- Course
- Assignment
- Feedback
- Promocode
- StudentHasPromocode
- CreditCard
- StudentAddCreditCard
- StudentTakeCourse
- StudentTakeAssignment
- StudentRateInstructor
- StudentCertifyCourse
- CoursePrerequisiteCourse
- InstructorTeachCourse

## Stored Procedures

The following stored procedures are implemented to handle various operations:

### Admin Functionalities

1. `AdminListInstr` - List all instructors.
2. `AdminViewInstructorProfile` - View profile of any instructor.
3. `AdminViewAllCourses` - List all courses.
4. `AdminViewNonAcceptedCourses` - List non-accepted courses.
5. `AdminViewCourseDetails` - View course details.
6. `AdminAcceptRejectCourse` - Accept or reject a course.
7. `AdminCreatePromocode` - Create a new promo code.
8. `AdminListAllStudents` - List all students.
9. `AdminViewStudentProfile` - View profile of any student.
10. `AdminIssuePromocodeToStudent` - Issue a promo code to a student.

### Instructor Functionalities

1. `InstAddCourse` - Add a new course.
2. `UpdateCourseContent` - Update course content.
3. `UpdateCourseDescription` - Update course description.
4. `AddAnotherInstructorToCourse` - Add another instructor to a course.
5. `InstructorViewAcceptedCoursesByAdmin` - View accepted courses.
6. `DefineCoursePrerequisites` - Define course prerequisites.
7. `DefineAssignmentOfCourseOfCertianType` - Define an assignment.
8. `ViewInstructorProfile` - View instructor profile.
9. `InstructorViewAssignmentsStudents` - View student assignments.
10. `InstructorgradeAssignmentOfAStudent` - Grade an assignment.
11. `ViewFeedbacksAddedByStudentsOnMyCourse` - View feedbacks.
12. `updateInstructorRate` - Update instructor rating.
13. `calculateFinalGrade` - Calculate final grade.
14. `InstructorIssueCertificateToStudent` - Issue certificate to student.

### Student Functionalities

1. `viewMyProfile` - View student profile.
2. `editMyProfile` - Edit student profile.
3. `availableCourses` - List available courses.
4. `courseInformation` - View course information.
5. `enrollInCourse` - Enroll in a course.
6. `addCreditCard` - Add a credit card.
7. `viewPromocode` - View promo codes.
8. `enrollInCourseViewContent` - View course content.
9. `viewAssign` - View assignments.
10. `submitAssign` - Submit assignment.
11. `viewAssignGrades` - View assignment grades.
12. `addFeedback` - Add feedback.
13. `rateInstructor` - Rate instructor.
14. `viewCertificate` - View certificate.
15. `viewFinalGrade` - View final grade.
16. `payCourse` - Pay for a course.

## Contributors

- **Mahmoud Nabil** (Component #1)
- **Anas ElNemr** (Component #2)
- **Ahmed Eltawel** (Component #3)
- **Ahmed Farouk** (Component #4)

### Notes

- Ensure SQL Server is running and accessible.
- Update the connection strings in the configuration files if necessary.
- For detailed implementation and usage, refer to the SQL script and stored procedures provided in the `GUCera.sql` file.

