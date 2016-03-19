
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/05/2016 09:22:44
-- Generated from EDMX file: D:\Projects\ABA\JobsInABA\JobsInABA.DAL\Entities\JobInABAModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [JobsInABA];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Address_Countries]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Addresses] DROP CONSTRAINT [FK_Address_Countries];
GO
IF OBJECT_ID(N'[dbo].[FK_Address_TypeCodes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Addresses] DROP CONSTRAINT [FK_Address_TypeCodes];
GO
IF OBJECT_ID(N'[dbo].[FK_BusinessAddresses_Address]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusinessAddresses] DROP CONSTRAINT [FK_BusinessAddresses_Address];
GO
IF OBJECT_ID(N'[dbo].[FK_UserAddresses_Address]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserAddresses] DROP CONSTRAINT [FK_UserAddresses_Address];
GO
IF OBJECT_ID(N'[dbo].[FK_Business_TypeCodes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Businesses] DROP CONSTRAINT [FK_Business_TypeCodes];
GO
IF OBJECT_ID(N'[dbo].[FK_Business_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Businesses] DROP CONSTRAINT [FK_Business_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Business_Users1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Businesses] DROP CONSTRAINT [FK_Business_Users1];
GO
IF OBJECT_ID(N'[dbo].[FK_BusinessAddresses_Business]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusinessAddresses] DROP CONSTRAINT [FK_BusinessAddresses_Business];
GO
IF OBJECT_ID(N'[dbo].[FK_BusinessEmails_Business]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusinessEmails] DROP CONSTRAINT [FK_BusinessEmails_Business];
GO
IF OBJECT_ID(N'[dbo].[FK_BusinessPhones_Business]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusinessPhones] DROP CONSTRAINT [FK_BusinessPhones_Business];
GO
IF OBJECT_ID(N'[dbo].[FK_BusinessUserMaps_Business]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusinessUserMaps] DROP CONSTRAINT [FK_BusinessUserMaps_Business];
GO
IF OBJECT_ID(N'[dbo].[FK_Jobs_Business]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Jobs] DROP CONSTRAINT [FK_Jobs_Business];
GO
IF OBJECT_ID(N'[dbo].[FK_BusinessEmails_Emails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusinessEmails] DROP CONSTRAINT [FK_BusinessEmails_Emails];
GO
IF OBJECT_ID(N'[dbo].[FK_BusinessUserMaps_TypeCodes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusinessUserMaps] DROP CONSTRAINT [FK_BusinessUserMaps_TypeCodes];
GO
IF OBJECT_ID(N'[dbo].[FK_BusinessUserMaps_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusinessUserMaps] DROP CONSTRAINT [FK_BusinessUserMaps_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_TypeCodes_ClassTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TypeCodes] DROP CONSTRAINT [FK_TypeCodes_ClassTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_Emails_TypeCodes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Emails] DROP CONSTRAINT [FK_Emails_TypeCodes];
GO
IF OBJECT_ID(N'[dbo].[FK_UserEmails_Emails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserEmails] DROP CONSTRAINT [FK_UserEmails_Emails];
GO
IF OBJECT_ID(N'[dbo].[FK_JobApplications_Jobs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JobApplications] DROP CONSTRAINT [FK_JobApplications_Jobs];
GO
IF OBJECT_ID(N'[dbo].[FK_JobApplications_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JobApplications] DROP CONSTRAINT [FK_JobApplications_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_JobApplicationStates_JobApplications]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JobApplicationStates] DROP CONSTRAINT [FK_JobApplicationStates_JobApplications];
GO
IF OBJECT_ID(N'[dbo].[FK_JobApplicationStates__TypeCodes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JobApplicationStates] DROP CONSTRAINT [FK_JobApplicationStates__TypeCodes];
GO
IF OBJECT_ID(N'[dbo].[FK_Jobs_TypeCodes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Jobs] DROP CONSTRAINT [FK_Jobs_TypeCodes];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRoles_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [FK_UserRoles_Roles];
GO
IF OBJECT_ID(N'[dbo].[FK_TypeCodes_TypeCodes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TypeCodes] DROP CONSTRAINT [FK_TypeCodes_TypeCodes];
GO
IF OBJECT_ID(N'[dbo].[FK_UserAccounts_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserAccounts] DROP CONSTRAINT [FK_UserAccounts_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_UserAddresses_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserAddresses] DROP CONSTRAINT [FK_UserAddresses_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_UserEmails_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserEmails] DROP CONSTRAINT [FK_UserEmails_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_UserPhones_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserPhones] DROP CONSTRAINT [FK_UserPhones_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRoles_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [FK_UserRoles_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Users_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Users_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Users_Users1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Users_Users1];
GO
IF OBJECT_ID(N'[dbo].[FK_BusinessPhones_Phones]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusinessPhones] DROP CONSTRAINT [FK_BusinessPhones_Phones];
GO
IF OBJECT_ID(N'[dbo].[FK_Phones_TypeCodes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Phones] DROP CONSTRAINT [FK_Phones_TypeCodes];
GO
IF OBJECT_ID(N'[dbo].[FK_UserPhones_Phones]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserPhones] DROP CONSTRAINT [FK_UserPhones_Phones];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Addresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Addresses];
GO
IF OBJECT_ID(N'[dbo].[Businesses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Businesses];
GO
IF OBJECT_ID(N'[dbo].[BusinessAddresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusinessAddresses];
GO
IF OBJECT_ID(N'[dbo].[BusinessEmails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusinessEmails];
GO
IF OBJECT_ID(N'[dbo].[BusinessPhones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusinessPhones];
GO
IF OBJECT_ID(N'[dbo].[BusinessUserMaps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusinessUserMaps];
GO
IF OBJECT_ID(N'[dbo].[ClassTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClassTypes];
GO
IF OBJECT_ID(N'[dbo].[Countries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Countries];
GO
IF OBJECT_ID(N'[dbo].[Emails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Emails];
GO
IF OBJECT_ID(N'[dbo].[JobApplications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobApplications];
GO
IF OBJECT_ID(N'[dbo].[JobApplicationStates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobApplicationStates];
GO
IF OBJECT_ID(N'[dbo].[Jobs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Jobs];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[TypeCodes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TypeCodes];
GO
IF OBJECT_ID(N'[dbo].[UserAccounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserAccounts];
GO
IF OBJECT_ID(N'[dbo].[UserAddresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserAddresses];
GO
IF OBJECT_ID(N'[dbo].[UserEmails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserEmails];
GO
IF OBJECT_ID(N'[dbo].[UserPhones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserPhones];
GO
IF OBJECT_ID(N'[dbo].[UserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRoles];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Phones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Phones];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [AddressID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(100)  NULL,
    [Line1] nvarchar(100)  NULL,
    [Line2] nvarchar(100)  NULL,
    [Line3] nvarchar(100)  NULL,
    [City] nvarchar(100)  NULL,
    [State] nvarchar(50)  NULL,
    [ZipCode] nvarchar(50)  NULL,
    [CountryID] int  NULL,
    [AddressTypeID] int  NULL
);
GO

-- Creating table 'Businesses'
CREATE TABLE [dbo].[Businesses] (
    [BusinessID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Abbreviation] nvarchar(10)  NULL,
    [StartDate] datetime  NULL,
    [BusinessTypeID] int  NOT NULL,
    [IsActive] bit  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [insuser] int  NULL,
    [insdt] datetime  NULL,
    [upduser] int  NULL,
    [upddt] datetime  NULL
);
GO

-- Creating table 'BusinessAddresses'
CREATE TABLE [dbo].[BusinessAddresses] (
    [BusinessAddressID] int IDENTITY(1,1) NOT NULL,
    [BusinessID] int  NOT NULL,
    [AddressID] int  NOT NULL,
    [IsPrimary] bit  NOT NULL
);
GO

-- Creating table 'BusinessEmails'
CREATE TABLE [dbo].[BusinessEmails] (
    [BusinessEmailID] int IDENTITY(1,1) NOT NULL,
    [BusinessID] int  NOT NULL,
    [EmailID] int  NOT NULL,
    [IsPrimary] bit  NOT NULL
);
GO

-- Creating table 'BusinessPhones'
CREATE TABLE [dbo].[BusinessPhones] (
    [BusinessPhoneID] int IDENTITY(1,1) NOT NULL,
    [BusinessID] int  NOT NULL,
    [PhoneID] int  NOT NULL,
    [IsPrimary] bit  NOT NULL
);
GO

-- Creating table 'BusinessUserMaps'
CREATE TABLE [dbo].[BusinessUserMaps] (
    [BusinessUserMapID] int IDENTITY(1,1) NOT NULL,
    [BusinessID] int  NOT NULL,
    [UserID] int  NOT NULL,
    [IsOwner] bit  NOT NULL,
    [BusinessUserTypeID] int  NULL
);
GO

-- Creating table 'ClassTypes'
CREATE TABLE [dbo].[ClassTypes] (
    [ClassTypeID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Code] varchar(10)  NOT NULL,
    [Description] varchar(200)  NULL
);
GO

-- Creating table 'Countries'
CREATE TABLE [dbo].[Countries] (
    [CountryID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Abbreviation] nvarchar(10)  NULL,
    [Code] varchar(10)  NULL,
    [PhoneCode] varchar(10)  NULL
);
GO

-- Creating table 'Emails'
CREATE TABLE [dbo].[Emails] (
    [EmailID] int  NOT NULL,
    [Address] nvarchar(100)  NULL,
    [EmailTypeID] int  NULL
);
GO

-- Creating table 'JobApplications'
CREATE TABLE [dbo].[JobApplications] (
    [JobApplicationID] int IDENTITY(1,1) NOT NULL,
    [JobID] int  NOT NULL,
    [ApplicantUserID] int  NOT NULL,
    [ApplicationDate] datetime  NOT NULL
);
GO

-- Creating table 'JobApplicationStates'
CREATE TABLE [dbo].[JobApplicationStates] (
    [JobApplicationStateID] int IDENTITY(1,1) NOT NULL,
    [JobApplicationID] int  NOT NULL,
    [JobApplicationStatusID] int  NOT NULL,
    [insdt] datetime  NOT NULL,
    [insuser] int  NOT NULL
);
GO

-- Creating table 'Jobs'
CREATE TABLE [dbo].[Jobs] (
    [JobID] int IDENTITY(1,1) NOT NULL,
    [BusinessID] int  NOT NULL,
    [Title] nvarchar(100)  NOT NULL,
    [Description] nvarchar(1000)  NULL,
    [JobTypeID] int  NULL,
    [IsActive] bit  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [StartDate] datetime  NULL,
    [EndDate] datetime  NULL,
    [insuser] int  NULL,
    [insdt] datetime  NULL,
    [upduser] int  NULL,
    [upddt] datetime  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [RoleID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Precedence] int  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'TypeCodes'
CREATE TABLE [dbo].[TypeCodes] (
    [TypeCodeID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Code] varchar(10)  NOT NULL,
    [Description] varchar(200)  NULL,
    [ClassTypeID] int  NOT NULL,
    [ParentTypeCodeID] int  NULL
);
GO

-- Creating table 'UserAccounts'
CREATE TABLE [dbo].[UserAccounts] (
    [UserAccountID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [UserName] nvarchar(100)  NOT NULL,
    [Password] varbinary(250)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [insuser] int  NULL,
    [insdt] datetime  NULL,
    [upduser] int  NULL,
    [upddt] datetime  NULL
);
GO

-- Creating table 'UserAddresses'
CREATE TABLE [dbo].[UserAddresses] (
    [UserAddressID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [AddressID] int  NOT NULL,
    [IsPrimary] bit  NOT NULL
);
GO

-- Creating table 'UserEmails'
CREATE TABLE [dbo].[UserEmails] (
    [UserEmailID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [EmailID] int  NOT NULL,
    [IsPrimary] bit  NOT NULL
);
GO

-- Creating table 'UserPhones'
CREATE TABLE [dbo].[UserPhones] (
    [UserPhoneID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [PhoneID] int  NOT NULL,
    [IsPrimary] bit  NOT NULL
);
GO

-- Creating table 'UserRoles'
CREATE TABLE [dbo].[UserRoles] (
    [UserRoleID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [RoleID] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [UserName] varchar(50)  NULL,
    [FirstName] nvarchar(100)  NOT NULL,
    [MiddleName] nvarchar(100)  NOT NULL,
    [LastName] nvarchar(100)  NOT NULL,
    [DOB] datetime  NULL,
    [IsActive] bit  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [insuser] int  NULL,
    [insdt] datetime  NULL,
    [upduser] int  NULL,
    [upddt] datetime  NULL
);
GO

-- Creating table 'Phones'
CREATE TABLE [dbo].[Phones] (
    [PhoneID] int IDENTITY(1,1) NOT NULL,
    [CountryID] int  NULL,
    [Number] varchar(20)  NULL,
    [Ext] varchar(10)  NULL,
    [PhoneTypeID] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AddressID] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([AddressID] ASC);
GO

-- Creating primary key on [BusinessID] in table 'Businesses'
ALTER TABLE [dbo].[Businesses]
ADD CONSTRAINT [PK_Businesses]
    PRIMARY KEY CLUSTERED ([BusinessID] ASC);
GO

-- Creating primary key on [BusinessAddressID] in table 'BusinessAddresses'
ALTER TABLE [dbo].[BusinessAddresses]
ADD CONSTRAINT [PK_BusinessAddresses]
    PRIMARY KEY CLUSTERED ([BusinessAddressID] ASC);
GO

-- Creating primary key on [BusinessEmailID] in table 'BusinessEmails'
ALTER TABLE [dbo].[BusinessEmails]
ADD CONSTRAINT [PK_BusinessEmails]
    PRIMARY KEY CLUSTERED ([BusinessEmailID] ASC);
GO

-- Creating primary key on [BusinessPhoneID] in table 'BusinessPhones'
ALTER TABLE [dbo].[BusinessPhones]
ADD CONSTRAINT [PK_BusinessPhones]
    PRIMARY KEY CLUSTERED ([BusinessPhoneID] ASC);
GO

-- Creating primary key on [BusinessUserMapID] in table 'BusinessUserMaps'
ALTER TABLE [dbo].[BusinessUserMaps]
ADD CONSTRAINT [PK_BusinessUserMaps]
    PRIMARY KEY CLUSTERED ([BusinessUserMapID] ASC);
GO

-- Creating primary key on [ClassTypeID] in table 'ClassTypes'
ALTER TABLE [dbo].[ClassTypes]
ADD CONSTRAINT [PK_ClassTypes]
    PRIMARY KEY CLUSTERED ([ClassTypeID] ASC);
GO

-- Creating primary key on [CountryID] in table 'Countries'
ALTER TABLE [dbo].[Countries]
ADD CONSTRAINT [PK_Countries]
    PRIMARY KEY CLUSTERED ([CountryID] ASC);
GO

-- Creating primary key on [EmailID] in table 'Emails'
ALTER TABLE [dbo].[Emails]
ADD CONSTRAINT [PK_Emails]
    PRIMARY KEY CLUSTERED ([EmailID] ASC);
GO

-- Creating primary key on [JobApplicationID] in table 'JobApplications'
ALTER TABLE [dbo].[JobApplications]
ADD CONSTRAINT [PK_JobApplications]
    PRIMARY KEY CLUSTERED ([JobApplicationID] ASC);
GO

-- Creating primary key on [JobApplicationStateID] in table 'JobApplicationStates'
ALTER TABLE [dbo].[JobApplicationStates]
ADD CONSTRAINT [PK_JobApplicationStates]
    PRIMARY KEY CLUSTERED ([JobApplicationStateID] ASC);
GO

-- Creating primary key on [JobID] in table 'Jobs'
ALTER TABLE [dbo].[Jobs]
ADD CONSTRAINT [PK_Jobs]
    PRIMARY KEY CLUSTERED ([JobID] ASC);
GO

-- Creating primary key on [RoleID] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [TypeCodeID] in table 'TypeCodes'
ALTER TABLE [dbo].[TypeCodes]
ADD CONSTRAINT [PK_TypeCodes]
    PRIMARY KEY CLUSTERED ([TypeCodeID] ASC);
GO

-- Creating primary key on [UserAccountID] in table 'UserAccounts'
ALTER TABLE [dbo].[UserAccounts]
ADD CONSTRAINT [PK_UserAccounts]
    PRIMARY KEY CLUSTERED ([UserAccountID] ASC);
GO

-- Creating primary key on [UserAddressID] in table 'UserAddresses'
ALTER TABLE [dbo].[UserAddresses]
ADD CONSTRAINT [PK_UserAddresses]
    PRIMARY KEY CLUSTERED ([UserAddressID] ASC);
GO

-- Creating primary key on [UserEmailID] in table 'UserEmails'
ALTER TABLE [dbo].[UserEmails]
ADD CONSTRAINT [PK_UserEmails]
    PRIMARY KEY CLUSTERED ([UserEmailID] ASC);
GO

-- Creating primary key on [UserPhoneID] in table 'UserPhones'
ALTER TABLE [dbo].[UserPhones]
ADD CONSTRAINT [PK_UserPhones]
    PRIMARY KEY CLUSTERED ([UserPhoneID] ASC);
GO

-- Creating primary key on [UserRoleID] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [PK_UserRoles]
    PRIMARY KEY CLUSTERED ([UserRoleID] ASC);
GO

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [PhoneID] in table 'Phones'
ALTER TABLE [dbo].[Phones]
ADD CONSTRAINT [PK_Phones]
    PRIMARY KEY CLUSTERED ([PhoneID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CountryID] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [FK_Address_Countries]
    FOREIGN KEY ([CountryID])
    REFERENCES [dbo].[Countries]
        ([CountryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Address_Countries'
CREATE INDEX [IX_FK_Address_Countries]
ON [dbo].[Addresses]
    ([CountryID]);
GO

-- Creating foreign key on [AddressTypeID] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [FK_Address_TypeCodes]
    FOREIGN KEY ([AddressTypeID])
    REFERENCES [dbo].[TypeCodes]
        ([TypeCodeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Address_TypeCodes'
CREATE INDEX [IX_FK_Address_TypeCodes]
ON [dbo].[Addresses]
    ([AddressTypeID]);
GO

-- Creating foreign key on [AddressID] in table 'BusinessAddresses'
ALTER TABLE [dbo].[BusinessAddresses]
ADD CONSTRAINT [FK_BusinessAddresses_Address]
    FOREIGN KEY ([AddressID])
    REFERENCES [dbo].[Addresses]
        ([AddressID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BusinessAddresses_Address'
CREATE INDEX [IX_FK_BusinessAddresses_Address]
ON [dbo].[BusinessAddresses]
    ([AddressID]);
GO

-- Creating foreign key on [AddressID] in table 'UserAddresses'
ALTER TABLE [dbo].[UserAddresses]
ADD CONSTRAINT [FK_UserAddresses_Address]
    FOREIGN KEY ([AddressID])
    REFERENCES [dbo].[Addresses]
        ([AddressID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserAddresses_Address'
CREATE INDEX [IX_FK_UserAddresses_Address]
ON [dbo].[UserAddresses]
    ([AddressID]);
GO

-- Creating foreign key on [BusinessTypeID] in table 'Businesses'
ALTER TABLE [dbo].[Businesses]
ADD CONSTRAINT [FK_Business_TypeCodes]
    FOREIGN KEY ([BusinessTypeID])
    REFERENCES [dbo].[TypeCodes]
        ([TypeCodeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Business_TypeCodes'
CREATE INDEX [IX_FK_Business_TypeCodes]
ON [dbo].[Businesses]
    ([BusinessTypeID]);
GO

-- Creating foreign key on [insuser] in table 'Businesses'
ALTER TABLE [dbo].[Businesses]
ADD CONSTRAINT [FK_Business_Users]
    FOREIGN KEY ([insuser])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Business_Users'
CREATE INDEX [IX_FK_Business_Users]
ON [dbo].[Businesses]
    ([insuser]);
GO

-- Creating foreign key on [upduser] in table 'Businesses'
ALTER TABLE [dbo].[Businesses]
ADD CONSTRAINT [FK_Business_Users1]
    FOREIGN KEY ([upduser])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Business_Users1'
CREATE INDEX [IX_FK_Business_Users1]
ON [dbo].[Businesses]
    ([upduser]);
GO

-- Creating foreign key on [BusinessID] in table 'BusinessAddresses'
ALTER TABLE [dbo].[BusinessAddresses]
ADD CONSTRAINT [FK_BusinessAddresses_Business]
    FOREIGN KEY ([BusinessID])
    REFERENCES [dbo].[Businesses]
        ([BusinessID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BusinessAddresses_Business'
CREATE INDEX [IX_FK_BusinessAddresses_Business]
ON [dbo].[BusinessAddresses]
    ([BusinessID]);
GO

-- Creating foreign key on [BusinessID] in table 'BusinessEmails'
ALTER TABLE [dbo].[BusinessEmails]
ADD CONSTRAINT [FK_BusinessEmails_Business]
    FOREIGN KEY ([BusinessID])
    REFERENCES [dbo].[Businesses]
        ([BusinessID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BusinessEmails_Business'
CREATE INDEX [IX_FK_BusinessEmails_Business]
ON [dbo].[BusinessEmails]
    ([BusinessID]);
GO

-- Creating foreign key on [BusinessID] in table 'BusinessPhones'
ALTER TABLE [dbo].[BusinessPhones]
ADD CONSTRAINT [FK_BusinessPhones_Business]
    FOREIGN KEY ([BusinessID])
    REFERENCES [dbo].[Businesses]
        ([BusinessID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BusinessPhones_Business'
CREATE INDEX [IX_FK_BusinessPhones_Business]
ON [dbo].[BusinessPhones]
    ([BusinessID]);
GO

-- Creating foreign key on [BusinessID] in table 'BusinessUserMaps'
ALTER TABLE [dbo].[BusinessUserMaps]
ADD CONSTRAINT [FK_BusinessUserMaps_Business]
    FOREIGN KEY ([BusinessID])
    REFERENCES [dbo].[Businesses]
        ([BusinessID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BusinessUserMaps_Business'
CREATE INDEX [IX_FK_BusinessUserMaps_Business]
ON [dbo].[BusinessUserMaps]
    ([BusinessID]);
GO

-- Creating foreign key on [BusinessID] in table 'Jobs'
ALTER TABLE [dbo].[Jobs]
ADD CONSTRAINT [FK_Jobs_Business]
    FOREIGN KEY ([BusinessID])
    REFERENCES [dbo].[Businesses]
        ([BusinessID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Jobs_Business'
CREATE INDEX [IX_FK_Jobs_Business]
ON [dbo].[Jobs]
    ([BusinessID]);
GO

-- Creating foreign key on [EmailID] in table 'BusinessEmails'
ALTER TABLE [dbo].[BusinessEmails]
ADD CONSTRAINT [FK_BusinessEmails_Emails]
    FOREIGN KEY ([EmailID])
    REFERENCES [dbo].[Emails]
        ([EmailID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BusinessEmails_Emails'
CREATE INDEX [IX_FK_BusinessEmails_Emails]
ON [dbo].[BusinessEmails]
    ([EmailID]);
GO

-- Creating foreign key on [BusinessUserTypeID] in table 'BusinessUserMaps'
ALTER TABLE [dbo].[BusinessUserMaps]
ADD CONSTRAINT [FK_BusinessUserMaps_TypeCodes]
    FOREIGN KEY ([BusinessUserTypeID])
    REFERENCES [dbo].[TypeCodes]
        ([TypeCodeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BusinessUserMaps_TypeCodes'
CREATE INDEX [IX_FK_BusinessUserMaps_TypeCodes]
ON [dbo].[BusinessUserMaps]
    ([BusinessUserTypeID]);
GO

-- Creating foreign key on [UserID] in table 'BusinessUserMaps'
ALTER TABLE [dbo].[BusinessUserMaps]
ADD CONSTRAINT [FK_BusinessUserMaps_Users]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BusinessUserMaps_Users'
CREATE INDEX [IX_FK_BusinessUserMaps_Users]
ON [dbo].[BusinessUserMaps]
    ([UserID]);
GO

-- Creating foreign key on [ClassTypeID] in table 'TypeCodes'
ALTER TABLE [dbo].[TypeCodes]
ADD CONSTRAINT [FK_TypeCodes_ClassTypes]
    FOREIGN KEY ([ClassTypeID])
    REFERENCES [dbo].[ClassTypes]
        ([ClassTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TypeCodes_ClassTypes'
CREATE INDEX [IX_FK_TypeCodes_ClassTypes]
ON [dbo].[TypeCodes]
    ([ClassTypeID]);
GO

-- Creating foreign key on [EmailTypeID] in table 'Emails'
ALTER TABLE [dbo].[Emails]
ADD CONSTRAINT [FK_Emails_TypeCodes]
    FOREIGN KEY ([EmailTypeID])
    REFERENCES [dbo].[TypeCodes]
        ([TypeCodeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Emails_TypeCodes'
CREATE INDEX [IX_FK_Emails_TypeCodes]
ON [dbo].[Emails]
    ([EmailTypeID]);
GO

-- Creating foreign key on [EmailID] in table 'UserEmails'
ALTER TABLE [dbo].[UserEmails]
ADD CONSTRAINT [FK_UserEmails_Emails]
    FOREIGN KEY ([EmailID])
    REFERENCES [dbo].[Emails]
        ([EmailID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserEmails_Emails'
CREATE INDEX [IX_FK_UserEmails_Emails]
ON [dbo].[UserEmails]
    ([EmailID]);
GO

-- Creating foreign key on [JobID] in table 'JobApplications'
ALTER TABLE [dbo].[JobApplications]
ADD CONSTRAINT [FK_JobApplications_Jobs]
    FOREIGN KEY ([JobID])
    REFERENCES [dbo].[Jobs]
        ([JobID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JobApplications_Jobs'
CREATE INDEX [IX_FK_JobApplications_Jobs]
ON [dbo].[JobApplications]
    ([JobID]);
GO

-- Creating foreign key on [JobID] in table 'JobApplications'
ALTER TABLE [dbo].[JobApplications]
ADD CONSTRAINT [FK_JobApplications_Users]
    FOREIGN KEY ([JobID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JobApplications_Users'
CREATE INDEX [IX_FK_JobApplications_Users]
ON [dbo].[JobApplications]
    ([JobID]);
GO

-- Creating foreign key on [JobApplicationID] in table 'JobApplicationStates'
ALTER TABLE [dbo].[JobApplicationStates]
ADD CONSTRAINT [FK_JobApplicationStates_JobApplications]
    FOREIGN KEY ([JobApplicationID])
    REFERENCES [dbo].[JobApplications]
        ([JobApplicationID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JobApplicationStates_JobApplications'
CREATE INDEX [IX_FK_JobApplicationStates_JobApplications]
ON [dbo].[JobApplicationStates]
    ([JobApplicationID]);
GO

-- Creating foreign key on [JobApplicationStatusID] in table 'JobApplicationStates'
ALTER TABLE [dbo].[JobApplicationStates]
ADD CONSTRAINT [FK_JobApplicationStates__TypeCodes]
    FOREIGN KEY ([JobApplicationStatusID])
    REFERENCES [dbo].[TypeCodes]
        ([TypeCodeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JobApplicationStates__TypeCodes'
CREATE INDEX [IX_FK_JobApplicationStates__TypeCodes]
ON [dbo].[JobApplicationStates]
    ([JobApplicationStatusID]);
GO

-- Creating foreign key on [JobTypeID] in table 'Jobs'
ALTER TABLE [dbo].[Jobs]
ADD CONSTRAINT [FK_Jobs_TypeCodes]
    FOREIGN KEY ([JobTypeID])
    REFERENCES [dbo].[TypeCodes]
        ([TypeCodeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Jobs_TypeCodes'
CREATE INDEX [IX_FK_Jobs_TypeCodes]
ON [dbo].[Jobs]
    ([JobTypeID]);
GO

-- Creating foreign key on [RoleID] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [FK_UserRoles_Roles]
    FOREIGN KEY ([RoleID])
    REFERENCES [dbo].[Roles]
        ([RoleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRoles_Roles'
CREATE INDEX [IX_FK_UserRoles_Roles]
ON [dbo].[UserRoles]
    ([RoleID]);
GO

-- Creating foreign key on [ParentTypeCodeID] in table 'TypeCodes'
ALTER TABLE [dbo].[TypeCodes]
ADD CONSTRAINT [FK_TypeCodes_TypeCodes]
    FOREIGN KEY ([ParentTypeCodeID])
    REFERENCES [dbo].[TypeCodes]
        ([TypeCodeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TypeCodes_TypeCodes'
CREATE INDEX [IX_FK_TypeCodes_TypeCodes]
ON [dbo].[TypeCodes]
    ([ParentTypeCodeID]);
GO

-- Creating foreign key on [UserID] in table 'UserAccounts'
ALTER TABLE [dbo].[UserAccounts]
ADD CONSTRAINT [FK_UserAccounts_Users]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserAccounts_Users'
CREATE INDEX [IX_FK_UserAccounts_Users]
ON [dbo].[UserAccounts]
    ([UserID]);
GO

-- Creating foreign key on [UserID] in table 'UserAddresses'
ALTER TABLE [dbo].[UserAddresses]
ADD CONSTRAINT [FK_UserAddresses_Users]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserAddresses_Users'
CREATE INDEX [IX_FK_UserAddresses_Users]
ON [dbo].[UserAddresses]
    ([UserID]);
GO

-- Creating foreign key on [UserID] in table 'UserEmails'
ALTER TABLE [dbo].[UserEmails]
ADD CONSTRAINT [FK_UserEmails_Users]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserEmails_Users'
CREATE INDEX [IX_FK_UserEmails_Users]
ON [dbo].[UserEmails]
    ([UserID]);
GO

-- Creating foreign key on [UserID] in table 'UserPhones'
ALTER TABLE [dbo].[UserPhones]
ADD CONSTRAINT [FK_UserPhones_Users]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPhones_Users'
CREATE INDEX [IX_FK_UserPhones_Users]
ON [dbo].[UserPhones]
    ([UserID]);
GO

-- Creating foreign key on [UserID] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [FK_UserRoles_Users]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRoles_Users'
CREATE INDEX [IX_FK_UserRoles_Users]
ON [dbo].[UserRoles]
    ([UserID]);
GO

-- Creating foreign key on [insuser] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_Users_Users]
    FOREIGN KEY ([insuser])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Users_Users'
CREATE INDEX [IX_FK_Users_Users]
ON [dbo].[Users]
    ([insuser]);
GO

-- Creating foreign key on [upduser] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_Users_Users1]
    FOREIGN KEY ([upduser])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Users_Users1'
CREATE INDEX [IX_FK_Users_Users1]
ON [dbo].[Users]
    ([upduser]);
GO

-- Creating foreign key on [PhoneID] in table 'BusinessPhones'
ALTER TABLE [dbo].[BusinessPhones]
ADD CONSTRAINT [FK_BusinessPhones_Phones]
    FOREIGN KEY ([PhoneID])
    REFERENCES [dbo].[Phones]
        ([PhoneID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BusinessPhones_Phones'
CREATE INDEX [IX_FK_BusinessPhones_Phones]
ON [dbo].[BusinessPhones]
    ([PhoneID]);
GO

-- Creating foreign key on [PhoneTypeID] in table 'Phones'
ALTER TABLE [dbo].[Phones]
ADD CONSTRAINT [FK_Phones_TypeCodes]
    FOREIGN KEY ([PhoneTypeID])
    REFERENCES [dbo].[TypeCodes]
        ([TypeCodeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Phones_TypeCodes'
CREATE INDEX [IX_FK_Phones_TypeCodes]
ON [dbo].[Phones]
    ([PhoneTypeID]);
GO

-- Creating foreign key on [PhoneID] in table 'UserPhones'
ALTER TABLE [dbo].[UserPhones]
ADD CONSTRAINT [FK_UserPhones_Phones]
    FOREIGN KEY ([PhoneID])
    REFERENCES [dbo].[Phones]
        ([PhoneID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPhones_Phones'
CREATE INDEX [IX_FK_UserPhones_Phones]
ON [dbo].[UserPhones]
    ([PhoneID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------