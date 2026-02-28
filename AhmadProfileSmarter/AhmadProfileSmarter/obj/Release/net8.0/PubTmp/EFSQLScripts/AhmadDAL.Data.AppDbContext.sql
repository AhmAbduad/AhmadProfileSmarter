IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE TABLE [Account] (
        [AccountID] int NOT NULL IDENTITY,
        [Email] nvarchar(100) NOT NULL,
        [AccountName] nvarchar(200) NOT NULL,
        [Password] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_Account] PRIMARY KEY ([AccountID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE TABLE [AIChatMessages] (
        [MessageId] int NOT NULL IDENTITY,
        [MessageText] nvarchar(1000) NOT NULL,
        CONSTRAINT [PK_AIChatMessages] PRIMARY KEY ([MessageId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE TABLE [EmployeeFiles] (
        [EmployeeFilesID] int NOT NULL IDENTITY,
        [ActualFileName] nvarchar(300) NULL,
        [ActualFile] varbinary(max) NULL,
        [Size] nvarchar(300) NULL,
        [UploadDate] datetime2 NULL,
        CONSTRAINT [PK_EmployeeFiles] PRIMARY KEY ([EmployeeFilesID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE TABLE [ParticipantFiles] (
        [ParticipantFilesID] int NOT NULL IDENTITY,
        [ActualFileName] nvarchar(300) NULL,
        [ActualFile] varbinary(max) NULL,
        [Size] nvarchar(300) NULL,
        [UploadDate] datetime2 NULL,
        CONSTRAINT [PK_ParticipantFiles] PRIMARY KEY ([ParticipantFilesID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE TABLE [PersonalFiles] (
        [PersonalFilesID] int NOT NULL IDENTITY,
        [ActualFileName] nvarchar(300) NULL,
        [ActualFile] varbinary(max) NULL,
        [Size] nvarchar(300) NULL,
        [UploadDate] datetime2 NULL,
        CONSTRAINT [PK_PersonalFiles] PRIMARY KEY ([PersonalFilesID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE TABLE [Reportbug] (
        [BugId] int NOT NULL IDENTITY,
        [title] nvarchar(100) NOT NULL,
        [description] nvarchar(255) NOT NULL,
        [attachment] varbinary(max) NULL,
        CONSTRAINT [PK_Reportbug] PRIMARY KEY ([BugId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE TABLE [Status] (
        [StatusID] int NOT NULL IDENTITY,
        [StatusName] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_Status] PRIMARY KEY ([StatusID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE TABLE [Users] (
        [UserId] int NOT NULL IDENTITY,
        [UserName] nvarchar(100) NOT NULL,
        [PasswordHash] nvarchar(255) NOT NULL,
        [Email] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE TABLE [Tasks] (
        [TaskID] int NOT NULL IDENTITY,
        [TaskName] nvarchar(300) NULL,
        [LateDays] nvarchar(100) NULL,
        [Salary] nvarchar(200) NULL,
        [LastActivity] datetime2 NULL,
        [StatusID] int NOT NULL,
        [AccountID] int NOT NULL,
        CONSTRAINT [PK_Tasks] PRIMARY KEY ([TaskID]),
        CONSTRAINT [FK_Tasks_Account_AccountID] FOREIGN KEY ([AccountID]) REFERENCES [Account] ([AccountID]) ON DELETE CASCADE,
        CONSTRAINT [FK_Tasks_Status_StatusID] FOREIGN KEY ([StatusID]) REFERENCES [Status] ([StatusID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE TABLE [AdminRequests] (
        [RequestId] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [RequestType] nvarchar(100) NOT NULL,
        [Title] nvarchar(200) NOT NULL,
        [Description] nvarchar(max) NULL,
        [Status] nvarchar(50) NOT NULL,
        [AdminRemarks] nvarchar(max) NULL,
        [CreatedAt] datetime2 NOT NULL,
        [UpdatedAt] datetime2 NULL,
        CONSTRAINT [PK_AdminRequests] PRIMARY KEY ([RequestId]),
        CONSTRAINT [FK_AdminRequests_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE TABLE [Chats] (
        [ChatID] int NOT NULL IDENTITY,
        [SenderID] int NOT NULL,
        [ReceiverID] int NOT NULL,
        [ChatText] nvarchar(max) NOT NULL,
        [MessageDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Chats] PRIMARY KEY ([ChatID]),
        CONSTRAINT [FK_Chats_Users_ReceiverID] FOREIGN KEY ([ReceiverID]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Chats_Users_SenderID] FOREIGN KEY ([SenderID]) REFERENCES [Users] ([UserId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE TABLE [Employee] (
        [EmployeeID] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [Designation] nvarchar(100) NULL,
        [Salary] decimal(10,2) NOT NULL,
        [JoinDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Employee] PRIMARY KEY ([EmployeeID]),
        CONSTRAINT [FK_Employee_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE TABLE [Notifications] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Message] nvarchar(max) NOT NULL,
        [NotificationType] nvarchar(max) NULL,
        [SenderId] int NULL,
        [ReceiverId] int NOT NULL,
        [IsRead] bit NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [IsDeleted] bit NOT NULL,
        CONSTRAINT [PK_Notifications] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Notifications_Users_ReceiverId] FOREIGN KEY ([ReceiverId]) REFERENCES [Users] ([UserId]),
        CONSTRAINT [FK_Notifications_Users_SenderId] FOREIGN KEY ([SenderId]) REFERENCES [Users] ([UserId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE TABLE [Activity] (
        [ActivityID] int NOT NULL IDENTITY,
        [TaskID] int NOT NULL,
        [ActivityText] nvarchar(800) NOT NULL,
        CONSTRAINT [PK_Activity] PRIMARY KEY ([ActivityID]),
        CONSTRAINT [FK_Activity_Tasks_TaskID] FOREIGN KEY ([TaskID]) REFERENCES [Tasks] ([TaskID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE TABLE [Attachment] (
        [AttachmentID] int NOT NULL IDENTITY,
        [TaskID] int NOT NULL,
        [AttachmentFile] varbinary(max) NOT NULL,
        [Size] nvarchar(200) NOT NULL,
        [UploadDate] datetime2 NOT NULL,
        [FileName] nvarchar(max) NOT NULL,
        [ContentType] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Attachment] PRIMARY KEY ([AttachmentID]),
        CONSTRAINT [FK_Attachment_Tasks_TaskID] FOREIGN KEY ([TaskID]) REFERENCES [Tasks] ([TaskID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE TABLE [Comments] (
        [CommentsID] int NOT NULL IDENTITY,
        [TaskID] int NOT NULL,
        [CommentsText] nvarchar(800) NOT NULL,
        CONSTRAINT [PK_Comments] PRIMARY KEY ([CommentsID]),
        CONSTRAINT [FK_Comments_Tasks_TaskID] FOREIGN KEY ([TaskID]) REFERENCES [Tasks] ([TaskID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE TABLE [Meetings] (
        [MeetingID] int NOT NULL IDENTITY,
        [Title] nvarchar(300) NOT NULL,
        [Description] nvarchar(300) NOT NULL,
        [StartTime] datetime2 NOT NULL,
        [EndTime] datetime2 NOT NULL,
        [MeetingLink] nvarchar(max) NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [UpdatedAt] datetime2 NOT NULL,
        [IsDeleted] bit NOT NULL,
        [TaskID] int NOT NULL,
        [CreatedBy] int NOT NULL,
        CONSTRAINT [PK_Meetings] PRIMARY KEY ([MeetingID]),
        CONSTRAINT [FK_Meetings_Tasks_TaskID] FOREIGN KEY ([TaskID]) REFERENCES [Tasks] ([TaskID]) ON DELETE CASCADE,
        CONSTRAINT [FK_Meetings_Users_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE TABLE [Participant] (
        [ParticipantID] int NOT NULL IDENTITY,
        [EmployeeID] int NOT NULL,
        [ParticipantName] nvarchar(100) NOT NULL,
        [IsActive] bit NOT NULL,
        CONSTRAINT [PK_Participant] PRIMARY KEY ([ParticipantID]),
        CONSTRAINT [FK_Participant_Employee_EmployeeID] FOREIGN KEY ([EmployeeID]) REFERENCES [Employee] ([EmployeeID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE TABLE [MeetingParticipants] (
        [Id] int NOT NULL IDENTITY,
        [MeetingID] int NOT NULL,
        [UserID] int NOT NULL,
        [IsHost] bit NOT NULL,
        [JoinedAt] datetime2 NULL,
        CONSTRAINT [PK_MeetingParticipants] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_MeetingParticipants_Meetings_MeetingID] FOREIGN KEY ([MeetingID]) REFERENCES [Meetings] ([MeetingID]) ON DELETE CASCADE,
        CONSTRAINT [FK_MeetingParticipants_Users_UserID] FOREIGN KEY ([UserID]) REFERENCES [Users] ([UserId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE INDEX [IX_Activity_TaskID] ON [Activity] ([TaskID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE INDEX [IX_AdminRequests_UserId] ON [AdminRequests] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE INDEX [IX_Attachment_TaskID] ON [Attachment] ([TaskID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE INDEX [IX_Chats_ReceiverID] ON [Chats] ([ReceiverID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE INDEX [IX_Chats_SenderID] ON [Chats] ([SenderID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE INDEX [IX_Comments_TaskID] ON [Comments] ([TaskID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE INDEX [IX_Employee_UserId] ON [Employee] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE INDEX [IX_MeetingParticipants_MeetingID] ON [MeetingParticipants] ([MeetingID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE INDEX [IX_MeetingParticipants_UserID] ON [MeetingParticipants] ([UserID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE INDEX [IX_Meetings_CreatedBy] ON [Meetings] ([CreatedBy]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE INDEX [IX_Meetings_TaskID] ON [Meetings] ([TaskID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE INDEX [IX_Notifications_ReceiverId] ON [Notifications] ([ReceiverId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE INDEX [IX_Notifications_SenderId] ON [Notifications] ([SenderId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE INDEX [IX_Participant_EmployeeID] ON [Participant] ([EmployeeID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE INDEX [IX_Tasks_AccountID] ON [Tasks] ([AccountID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    CREATE INDEX [IX_Tasks_StatusID] ON [Tasks] ([StatusID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260226105415_MigrationV1'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260226105415_MigrationV1', N'8.0.0');
END;
GO

COMMIT;
GO

