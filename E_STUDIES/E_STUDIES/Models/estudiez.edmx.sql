
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/13/2022 20:41:28
-- Generated from EDMX file: D:\Techwizestudies\E_STUDIES\E_STUDIES\Models\estudiez.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [estudiez];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Academic___Score__3A81B327]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Academic_process] DROP CONSTRAINT [FK__Academic___Score__3A81B327];
GO
IF OBJECT_ID(N'[dbo].[FK__Contact_u__useri__29572725]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contact_us] DROP CONSTRAINT [FK__Contact_u__useri__29572725];
GO
IF OBJECT_ID(N'[dbo].[FK__Feedback__userid__2C3393D0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Feedbacks] DROP CONSTRAINT [FK__Feedback__userid__2C3393D0];
GO
IF OBJECT_ID(N'[dbo].[FK__Parents_d__useri__403A8C7D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Parents_data] DROP CONSTRAINT [FK__Parents_d__useri__403A8C7D];
GO
IF OBJECT_ID(N'[dbo].[FK__Revision___useri__31EC6D26]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Revision_classes] DROP CONSTRAINT [FK__Revision___useri__31EC6D26];
GO
IF OBJECT_ID(N'[dbo].[FK__Score_det__useri__37A5467C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Score_details] DROP CONSTRAINT [FK__Score_det__useri__37A5467C];
GO
IF OBJECT_ID(N'[dbo].[FK__Student_d__Teach__48CFD27E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Student_data] DROP CONSTRAINT [FK__Student_d__Teach__48CFD27E];
GO
IF OBJECT_ID(N'[dbo].[FK__Student_d__useri__49C3F6B7]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Student_data] DROP CONSTRAINT [FK__Student_d__useri__49C3F6B7];
GO
IF OBJECT_ID(N'[dbo].[FK__Study_res__useri__2F10007B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Study_resources] DROP CONSTRAINT [FK__Study_res__useri__2F10007B];
GO
IF OBJECT_ID(N'[dbo].[FK__Teacher_d__useri__45F365D3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Teacher_data] DROP CONSTRAINT [FK__Teacher_d__useri__45F365D3];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Academic_process]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Academic_process];
GO
IF OBJECT_ID(N'[dbo].[Contact_us]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contact_us];
GO
IF OBJECT_ID(N'[dbo].[Feedbacks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Feedbacks];
GO
IF OBJECT_ID(N'[dbo].[Parents_data]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Parents_data];
GO
IF OBJECT_ID(N'[dbo].[Revision_classes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Revision_classes];
GO
IF OBJECT_ID(N'[dbo].[Score_details]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Score_details];
GO
IF OBJECT_ID(N'[dbo].[Student_data]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Student_data];
GO
IF OBJECT_ID(N'[dbo].[Study_resources]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Study_resources];
GO
IF OBJECT_ID(N'[dbo].[Teacher_data]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Teacher_data];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [userid] int IDENTITY(1,1) NOT NULL,
    [Email_ID] varchar(250)  NULL,
    [phone] bigint  NULL,
    [user_name] varchar(250)  NULL,
    [User_password] varchar(250)  NULL,
    [User_role] int  NULL
);
GO

-- Creating table 'Academic_process'
CREATE TABLE [dbo].[Academic_process] (
    [Academic_process_id] int IDENTITY(1,1) NOT NULL,
    [Score_id] int  NULL,
    [Academic_Message] varchar(400)  NULL
);
GO

-- Creating table 'Contact_us'
CREATE TABLE [dbo].[Contact_us] (
    [Contact_us_id] int IDENTITY(1,1) NOT NULL,
    [userid] int  NULL,
    [Subjects] varchar(250)  NULL,
    [Contact_us_messages] varchar(400)  NULL,
    [email] varchar(200)  NULL
);
GO

-- Creating table 'Parents_data'
CREATE TABLE [dbo].[Parents_data] (
    [Parents_data_id] int IDENTITY(1,1) NOT NULL,
    [Parent_Name] varchar(250)  NULL,
    [phone] bigint  NULL,
    [Cnic] varchar(20)  NULL,
    [Parents_address] varchar(250)  NULL,
    [userid] int  NULL
);
GO

-- Creating table 'Revision_classes'
CREATE TABLE [dbo].[Revision_classes] (
    [Revision_class_id] int IDENTITY(1,1) NOT NULL,
    [Class_start_date] datetime  NULL,
    [Class_time] time  NULL,
    [userid] int  NULL
);
GO

-- Creating table 'Score_details'
CREATE TABLE [dbo].[Score_details] (
    [Score_id] int IDENTITY(1,1) NOT NULL,
    [Total_Marks] int  NULL,
    [Score_receive] int  NULL,
    [Issued_date] datetime  NULL,
    [Score_description] varchar(400)  NULL,
    [userid] int  NULL,
    [course] varchar(60)  NULL
);
GO

-- Creating table 'Student_data'
CREATE TABLE [dbo].[Student_data] (
    [Student_data_id] int IDENTITY(1,1) NOT NULL,
    [Fullname] varchar(250)  NULL,
    [Enrollment_date] datetime  NULL,
    [Student_address] varchar(250)  NULL,
    [Student_age] int  NULL,
    [phone] bigint  NULL,
    [Student_image] varchar(250)  NULL,
    [Teacher_data_id] int  NULL,
    [userid] int  NULL,
    [Gender] varchar(20)  NULL
);
GO

-- Creating table 'Study_resources'
CREATE TABLE [dbo].[Study_resources] (
    [Resources_id] int IDENTITY(1,1) NOT NULL,
    [Title] varchar(250)  NULL,
    [Url_link] varchar(250)  NULL,
    [userid] int  NULL,
    [Res_status] bit  NULL,
    [res_desc] varchar(20)  NULL,
    [res_img] varchar(20)  NULL
);
GO

-- Creating table 'Teacher_data'
CREATE TABLE [dbo].[Teacher_data] (
    [Teacher_data_id] int IDENTITY(1,1) NOT NULL,
    [Fullname] varchar(250)  NULL,
    [Teacher_image] varchar(250)  NULL,
    [phone] bigint  NULL,
    [userid] int  NULL,
    [Teacher_address] varchar(250)  NULL,
    [Marital_status] varchar(250)  NULL,
    [age] int  NULL,
    [gender] varchar(20)  NULL,
    [Qualification] varchar(20)  NULL,
    [Experience] varchar(20)  NULL
);
GO

-- Creating table 'Feedbacks'
CREATE TABLE [dbo].[Feedbacks] (
    [Feedback_id] int IDENTITY(1,1) NOT NULL,
    [userid] int  NULL,
    [Subjects] varchar(250)  NULL,
    [Feedback_messages] varchar(400)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [userid] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([userid] ASC);
GO

-- Creating primary key on [Academic_process_id] in table 'Academic_process'
ALTER TABLE [dbo].[Academic_process]
ADD CONSTRAINT [PK_Academic_process]
    PRIMARY KEY CLUSTERED ([Academic_process_id] ASC);
GO

-- Creating primary key on [Contact_us_id] in table 'Contact_us'
ALTER TABLE [dbo].[Contact_us]
ADD CONSTRAINT [PK_Contact_us]
    PRIMARY KEY CLUSTERED ([Contact_us_id] ASC);
GO

-- Creating primary key on [Parents_data_id] in table 'Parents_data'
ALTER TABLE [dbo].[Parents_data]
ADD CONSTRAINT [PK_Parents_data]
    PRIMARY KEY CLUSTERED ([Parents_data_id] ASC);
GO

-- Creating primary key on [Revision_class_id] in table 'Revision_classes'
ALTER TABLE [dbo].[Revision_classes]
ADD CONSTRAINT [PK_Revision_classes]
    PRIMARY KEY CLUSTERED ([Revision_class_id] ASC);
GO

-- Creating primary key on [Score_id] in table 'Score_details'
ALTER TABLE [dbo].[Score_details]
ADD CONSTRAINT [PK_Score_details]
    PRIMARY KEY CLUSTERED ([Score_id] ASC);
GO

-- Creating primary key on [Student_data_id] in table 'Student_data'
ALTER TABLE [dbo].[Student_data]
ADD CONSTRAINT [PK_Student_data]
    PRIMARY KEY CLUSTERED ([Student_data_id] ASC);
GO

-- Creating primary key on [Resources_id] in table 'Study_resources'
ALTER TABLE [dbo].[Study_resources]
ADD CONSTRAINT [PK_Study_resources]
    PRIMARY KEY CLUSTERED ([Resources_id] ASC);
GO

-- Creating primary key on [Teacher_data_id] in table 'Teacher_data'
ALTER TABLE [dbo].[Teacher_data]
ADD CONSTRAINT [PK_Teacher_data]
    PRIMARY KEY CLUSTERED ([Teacher_data_id] ASC);
GO

-- Creating primary key on [Feedback_id] in table 'Feedbacks'
ALTER TABLE [dbo].[Feedbacks]
ADD CONSTRAINT [PK_Feedbacks]
    PRIMARY KEY CLUSTERED ([Feedback_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Score_id] in table 'Academic_process'
ALTER TABLE [dbo].[Academic_process]
ADD CONSTRAINT [FK__Academic___Score__3A81B327]
    FOREIGN KEY ([Score_id])
    REFERENCES [dbo].[Score_details]
        ([Score_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Academic___Score__3A81B327'
CREATE INDEX [IX_FK__Academic___Score__3A81B327]
ON [dbo].[Academic_process]
    ([Score_id]);
GO

-- Creating foreign key on [userid] in table 'Contact_us'
ALTER TABLE [dbo].[Contact_us]
ADD CONSTRAINT [FK__Contact_u__useri__29572725]
    FOREIGN KEY ([userid])
    REFERENCES [dbo].[Users]
        ([userid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Contact_u__useri__29572725'
CREATE INDEX [IX_FK__Contact_u__useri__29572725]
ON [dbo].[Contact_us]
    ([userid]);
GO

-- Creating foreign key on [userid] in table 'Parents_data'
ALTER TABLE [dbo].[Parents_data]
ADD CONSTRAINT [FK__Parents_d__useri__403A8C7D]
    FOREIGN KEY ([userid])
    REFERENCES [dbo].[Users]
        ([userid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Parents_d__useri__403A8C7D'
CREATE INDEX [IX_FK__Parents_d__useri__403A8C7D]
ON [dbo].[Parents_data]
    ([userid]);
GO

-- Creating foreign key on [userid] in table 'Revision_classes'
ALTER TABLE [dbo].[Revision_classes]
ADD CONSTRAINT [FK__Revision___useri__31EC6D26]
    FOREIGN KEY ([userid])
    REFERENCES [dbo].[Users]
        ([userid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Revision___useri__31EC6D26'
CREATE INDEX [IX_FK__Revision___useri__31EC6D26]
ON [dbo].[Revision_classes]
    ([userid]);
GO

-- Creating foreign key on [userid] in table 'Score_details'
ALTER TABLE [dbo].[Score_details]
ADD CONSTRAINT [FK__Score_det__useri__37A5467C]
    FOREIGN KEY ([userid])
    REFERENCES [dbo].[Users]
        ([userid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Score_det__useri__37A5467C'
CREATE INDEX [IX_FK__Score_det__useri__37A5467C]
ON [dbo].[Score_details]
    ([userid]);
GO

-- Creating foreign key on [Teacher_data_id] in table 'Student_data'
ALTER TABLE [dbo].[Student_data]
ADD CONSTRAINT [FK__Student_d__Teach__48CFD27E]
    FOREIGN KEY ([Teacher_data_id])
    REFERENCES [dbo].[Teacher_data]
        ([Teacher_data_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Student_d__Teach__48CFD27E'
CREATE INDEX [IX_FK__Student_d__Teach__48CFD27E]
ON [dbo].[Student_data]
    ([Teacher_data_id]);
GO

-- Creating foreign key on [userid] in table 'Student_data'
ALTER TABLE [dbo].[Student_data]
ADD CONSTRAINT [FK__Student_d__useri__49C3F6B7]
    FOREIGN KEY ([userid])
    REFERENCES [dbo].[Users]
        ([userid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Student_d__useri__49C3F6B7'
CREATE INDEX [IX_FK__Student_d__useri__49C3F6B7]
ON [dbo].[Student_data]
    ([userid]);
GO

-- Creating foreign key on [userid] in table 'Study_resources'
ALTER TABLE [dbo].[Study_resources]
ADD CONSTRAINT [FK__Study_res__useri__2F10007B]
    FOREIGN KEY ([userid])
    REFERENCES [dbo].[Users]
        ([userid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Study_res__useri__2F10007B'
CREATE INDEX [IX_FK__Study_res__useri__2F10007B]
ON [dbo].[Study_resources]
    ([userid]);
GO

-- Creating foreign key on [userid] in table 'Teacher_data'
ALTER TABLE [dbo].[Teacher_data]
ADD CONSTRAINT [FK__Teacher_d__useri__45F365D3]
    FOREIGN KEY ([userid])
    REFERENCES [dbo].[Users]
        ([userid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Teacher_d__useri__45F365D3'
CREATE INDEX [IX_FK__Teacher_d__useri__45F365D3]
ON [dbo].[Teacher_data]
    ([userid]);
GO

-- Creating foreign key on [userid] in table 'Feedbacks'
ALTER TABLE [dbo].[Feedbacks]
ADD CONSTRAINT [FK__Feedback__userid__2C3393D0]
    FOREIGN KEY ([userid])
    REFERENCES [dbo].[Users]
        ([userid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Feedback__userid__2C3393D0'
CREATE INDEX [IX_FK__Feedback__userid__2C3393D0]
ON [dbo].[Feedbacks]
    ([userid]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------