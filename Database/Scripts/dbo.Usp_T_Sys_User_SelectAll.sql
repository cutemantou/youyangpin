

IF OBJECT_ID(N'[dbo].[Usp_T_Sys_User_SelectAll]') IS NOT NULL
BEGIN
	PRINT 'Dropping Procedure [dbo].[Usp_T_Sys_User_SelectAll]'
	DROP PROCEDURE [dbo].[Usp_T_Sys_User_SelectAll]
END


GO

PRINT 'Create Procedure [dbo].[Usp_T_Sys_User_SelectAll]'

GO

CREATE PROCEDURE [dbo].[Usp_T_Sys_User_SelectAll]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[GUID],
	[Account],
	[Pwd],
	[UserState],
	[UserType],
	[TrueName],
	[DepartmentGuid],
	[PositionGuid],
	[LastLoginTime],
	[LastLoginIP],
	[LoginTimes],
	[LoginErrorTimes],
	[CreatePerson],
	[CreateTime],
	[ExpirationDate],
	[QQ],
	[IsAdmin],
	[TelPhone],
	[QQGroup],
	[ReturnInfo],
	[CityName],
	[ProvinceName],
	[Email],
	[Gender],
	[ZFBAccount],
	[UpdateTime]
FROM
	[dbo].[T_Sys_User]

GO

--GRANT EXEC ON [dbo].[Usp_T_Sys_User_SelectAll] TO shafeUser

GO

