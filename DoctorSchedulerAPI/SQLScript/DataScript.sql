USE [MedicalManagement]
GO
SET IDENTITY_INSERT [dbo].[Doctors] ON 

INSERT [dbo].[Doctors] ([Id], [FirstName], [LastName], [DateOfBirth], [PhoneNumber], [Email], [Degree], [Qualification], [Specialization]) VALUES (3, N'Punitha', N'Guruswamy', CAST(N'2019-10-14T00:00:00.0000000' AS DateTime2), N'579384', N'fdsfsdf', N'fgsdfg', N'MD', N'Cardiologist')
INSERT [dbo].[Doctors] ([Id], [FirstName], [LastName], [DateOfBirth], [PhoneNumber], [Email], [Degree], [Qualification], [Specialization]) VALUES (5, N'Uma', NULL, CAST(N'2019-09-11T00:00:00.0000000' AS DateTime2), N'2435234', N'rtdfgsdfg', N'gs', N'MBBS', N'General')
INSERT [dbo].[Doctors] ([Id], [FirstName], [LastName], [DateOfBirth], [PhoneNumber], [Email], [Degree], [Qualification], [Specialization]) VALUES (6, NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Doctors] OFF
SET IDENTITY_INSERT [dbo].[Diseases] ON 

INSERT [dbo].[Diseases] ([Id], [name], [Description]) VALUES (1, N'Diabetis', NULL)
INSERT [dbo].[Diseases] ([Id], [name], [Description]) VALUES (2, N'BloodPressure', NULL)
INSERT [dbo].[Diseases] ([Id], [name], [Description]) VALUES (3, N'Cancer', NULL)
INSERT [dbo].[Diseases] ([Id], [name], [Description]) VALUES (4, N'AIDS', NULL)
INSERT [dbo].[Diseases] ([Id], [name], [Description]) VALUES (5, N'Arthritis', NULL)
INSERT [dbo].[Diseases] ([Id], [name], [Description]) VALUES (6, N'Reheumatoid', NULL)
INSERT [dbo].[Diseases] ([Id], [name], [Description]) VALUES (7, N'Fertiliy', NULL)
INSERT [dbo].[Diseases] ([Id], [name], [Description]) VALUES (8, N'HeartDiesase', NULL)
INSERT [dbo].[Diseases] ([Id], [name], [Description]) VALUES (9, N'Anemic', NULL)
INSERT [dbo].[Diseases] ([Id], [name], [Description]) VALUES (10, N'Schzopeneia', NULL)
INSERT [dbo].[Diseases] ([Id], [name], [Description]) VALUES (11, N'Tumor', NULL)
SET IDENTITY_INSERT [dbo].[Diseases] OFF
SET IDENTITY_INSERT [dbo].[Patients] ON 

INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [DateOfBirth], [PhoneNumber], [Email], [DiseaseId]) VALUES (2, N'Patient1', N'Patient1L', CAST(N'1978-07-21T00:00:00.0000000' AS DateTime2), N'3434', N'fgsdfg', 1)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [DateOfBirth], [PhoneNumber], [Email], [DiseaseId]) VALUES (3, N'Patient2', N'Patient2L', CAST(N'1985-03-04T00:00:00.0000000' AS DateTime2), N'857685', N'fgghf', 2)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [DateOfBirth], [PhoneNumber], [Email], [DiseaseId]) VALUES (5, N'Patient3', NULL, CAST(N'1956-03-08T00:00:00.0000000' AS DateTime2), N'234523452', N'ertz', 3)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [DateOfBirth], [PhoneNumber], [Email], [DiseaseId]) VALUES (7, N'Patient4', NULL, CAST(N'1999-08-24T00:00:00.0000000' AS DateTime2), NULL, N'hfgdgh', 5)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [DateOfBirth], [PhoneNumber], [Email], [DiseaseId]) VALUES (8, N'Hans-Peter', N'Wagner', CAST(N'2000-09-26T12:00:00.0000000' AS DateTime2), N'568278724837598', N'blaba@yahoo.com', 1)
SET IDENTITY_INSERT [dbo].[Patients] OFF
SET IDENTITY_INSERT [dbo].[Appointment] ON 

INSERT [dbo].[Appointment] ([Id], [DoctorId], [PatientId], [AppFrom], [AppTo], [Description]) VALUES (8, 3, 2, CAST(N'2019-09-25T13:00:00.0000000' AS DateTime2), CAST(N'2019-09-25T13:40:00.0000000' AS DateTime2), N'fsdfg')
INSERT [dbo].[Appointment] ([Id], [DoctorId], [PatientId], [AppFrom], [AppTo], [Description]) VALUES (11, 5, 5, CAST(N'2019-09-25T14:30:00.0000000' AS DateTime2), CAST(N'2019-09-25T15:00:00.0000000' AS DateTime2), N'ghfgfd')
INSERT [dbo].[Appointment] ([Id], [DoctorId], [PatientId], [AppFrom], [AppTo], [Description]) VALUES (10002, 3, 7, CAST(N'2019-09-26T13:00:00.0000000' AS DateTime2), CAST(N'2019-09-26T13:30:00.0000000' AS DateTime2), N'Test From postman')
INSERT [dbo].[Appointment] ([Id], [DoctorId], [PatientId], [AppFrom], [AppTo], [Description]) VALUES (10003, 5, 7, CAST(N'2019-09-26T13:00:00.0000000' AS DateTime2), CAST(N'2019-09-26T13:40:00.0000000' AS DateTime2), N'Upddated through HttpPutt')
INSERT [dbo].[Appointment] ([Id], [DoctorId], [PatientId], [AppFrom], [AppTo], [Description]) VALUES (10004, 5, 7, CAST(N'2019-09-26T12:00:00.0000000' AS DateTime2), CAST(N'2019-09-26T12:40:00.0000000' AS DateTime2), N'Upddated through Punitha Guruswamy')
INSERT [dbo].[Appointment] ([Id], [DoctorId], [PatientId], [AppFrom], [AppTo], [Description]) VALUES (20002, 3, 7, CAST(N'2019-09-29T13:00:00.0000000' AS DateTime2), CAST(N'2019-09-29T13:00:00.0000000' AS DateTime2), N'New Descripton')
SET IDENTITY_INSERT [dbo].[Appointment] OFF
