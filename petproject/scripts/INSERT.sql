BEGIN TRANSACTION;

BEGIN TRY
    -- Insert Courses
    INSERT INTO Courses (CourseId, Title, Description) VALUES 
    ('1b7b40e6-46e3-4e09-9e43-9d2c5a1f2b94', 'Introduction to Programming', 'Learn the basics of programming.'),
    ('a5b6c44a-f2ed-4a6a-8f2e-1d1e0c44b038', 'Advanced Programming', 'Deep dive into advanced programming concepts.');

    -- Insert Chapters
    INSERT INTO Chapters (ChapterId, Title, Description, MaterialUrl, CourseId) VALUES 
    ('3d704a6e-f3e8-44d7-9b1d-40798a02b3d2', 'Getting Started', 'Introduction to the course.', 'http://example.com/start', '1b7b40e6-46e3-4e09-9e43-9d2c5a1f2b94'),
    ('c92e2d27-5cb2-493e-925c-d17f68d58c3e', 'Advanced Topics', 'In-depth coverage of advanced topics.', 'http://example.com/advanced', 'a5b6c44a-f2ed-4a6a-8f2e-1d1e0c44b038');

    -- Insert CoursesEnrollments
    INSERT INTO CourseEnrollments (CourseEnrollmentId, StartDate, EndDate, CourseState, CourseId) VALUES 
    ('6e07f702-6b9a-4090-9f63-22d09d3d2b87', '2024-01-01', '2024-06-30', 0, '1b7b40e6-46e3-4e09-9e43-9d2c5a1f2b94'),
    ('7b3e56b7-cffb-4e6e-9d56-4b9e5a0e9c53', '2024-02-01', '2024-07-30', 1, 'a5b6c44a-f2ed-4a6a-8f2e-1d1e0c44b038');

    -- Insert Trainees
    INSERT INTO Trainees (TraineeId, Name, Email) VALUES 
    ('d6f9e4e3-b5a3-45f8-a8cc-0d58f6c82a8e', 'Alice Smith', 'alice@example.com'),
    ('e7a9f7a1-d9b0-4e4f-bfe6-30f34b33455a', 'Bob Johnson', 'bob@example.com');

    -- Insert Trainers
    INSERT INTO Trainers (TrainerId, Name, Email) VALUES 
    ('3a6b7c8d-e7f9-4f99-93e6-8a7b6c7f9c87', 'Dr. John Doe', 'john.doe@example.com'),
    ('2d1e9a0c-f1f4-4c66-8d4c-3b8b6e8e9a7c', 'Dr. Jane Roe', 'jane.roe@example.com');

    -- Insert CourseProgress
    INSERT INTO CourseProgresses (CourseProgressId, TraineeId, CourseEnrollmentId, PercentageDone) VALUES 
    ('f1c6e4d7-9c1a-4b9d-8b07-1e1e7f8c6b2a', 'd6f9e4e3-b5a3-45f8-a8cc-0d58f6c82a8e', '6e07f702-6b9a-4090-9f63-22d09d3d2b87', 60.0),
    ('a8d3e7c6-6f1a-4d9b-9b7e-2b1e6e8d9c3b', 'e7a9f7a1-d9b0-4e4f-bfe6-30f34b33455a', '7b3e56b7-cffb-4e6e-9d56-4b9e5a0e9c53', 80.0);

    -- Insert ChapterEnrollments
    INSERT INTO ChapterEnrollments (ChapterEnrollmentId, ChapterId, CourseEnrollmentId) VALUES 
    ('b2d6a9c7-3c8d-4a5b-a0e7-f35d5a1f9b8d', '3d704a6e-f3e8-44d7-9b1d-40798a02b3d2', '6e07f702-6b9a-4090-9f63-22d09d3d2b87'),
    ('a3e9c7b0-48f2-4c57-b1b0-4b8b5e8f4c2f', 'c92e2d27-5cb2-493e-925c-d17f68d58c3e', '7b3e56b7-cffb-4e6e-9d56-4b9e5a0e9c53');

    -- Insert ChapterProgress
    INSERT INTO ChapterProgresses (ChapterProgressId, CourseProgressId, ChapterEnrollmentId, PercentageDone) VALUES 
    ('f8b6a3c1-4d2a-4e7a-9d93-2f9a5e4b7e83', 'f1c6e4d7-9c1a-4b9d-8b07-1e1e7f8c6b2a', 'b2d6a9c7-3c8d-4a5b-a0e7-f35d5a1f9b8d', 50.0),
    ('d4a6b5e0-7e6f-4d6b-bf3a-3d5b4e6f9a7c', 'a8d3e7c6-6f1a-4d9b-9b7e-2b1e6e8d9c3b', 'a3e9c7b0-48f2-4c57-b1b0-4b8b5e8f4c2f', 75.0);

    -- Insert ProgressReports
    INSERT INTO ProgressReports (ProgressReportId, Content, PublishDate, CourseProgressId) VALUES 
    ('b1a6e2c9-5d8f-4b67-b8d1-d9e5f4b7c8a6', 'Report on progress for Chapter 1.', '2024-05-01', 'f1c6e4d7-9c1a-4b9d-8b07-1e1e7f8c6b2a'),
    ('c7e4d8b3-9c7f-4e6a-8d7e-1f2a5e8c9b8d', 'Report on progress for Chapter 2.', '2024-06-01', 'a8d3e7c6-6f1a-4d9b-9b7e-2b1e6e8d9c3b');

    -- Insert CourseEnrollmentTrainers
    INSERT INTO CourseEnrollmentTrainers (CourseEnrollmentId, TrainerId) VALUES 
    ('6e07f702-6b9a-4090-9f63-22d09d3d2b87', '3a6b7c8d-e7f9-4f99-93e6-8a7b6c7f9c87'),
    ('7b3e56b7-cffb-4e6e-9d56-4b9e5a0e9c53', '2d1e9a0c-f1f4-4c66-8d4c-3b8b6e8e9a7c');

    -- Insert CourseEnrollmentTrainees
    INSERT INTO CourseEnrollmentTrainees (CourseEnrollmentId, TraineeId) VALUES 
    ('6e07f702-6b9a-4090-9f63-22d09d3d2b87', 'd6f9e4e3-b5a3-45f8-a8cc-0d58f6c82a8e'),
    ('7b3e56b7-cffb-4e6e-9d56-4b9e5a0e9c53', 'e7a9f7a1-d9b0-4e4f-bfe6-30f34b33455a');



    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    THROW;
END CATCH;
