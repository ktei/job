USE [mPort];
GO
CREATE PROCEDURE sp_get_avg_waist_by_email
    @email nvarchar(100)
AS 
BEGIN
    SET NOCOUNT ON;
    
    DECLARE
    @waist float
	    
    SELECT @waist = AVG(s.waist) FROM [scans] AS s join [members] AS m ON s.member_id = m.id
	WHERE m.email = @email;
	
	IF @waist >= 77 AND @waist < 82
		RETURN 30
	ELSE IF @waist >= 82 AND @waist < 84
		RETURN 32
	ELSE IF @waist >= 84 AND @waist < 87
		RETURN 33
	ELSE IF @waist >= 87 AND @waist < 92
		RETURN 34
	ELSE IF @waist >= 92 AND @waist < 97
		RETURN 36
	ELSE IF @waist >= 97 AND @waist < 102
		RETURN 38
	ELSE IF @waist >= 102 AND @waist < 107
		RETURN 40
	ELSE IF @waist >= 107
		RETURN 42
	ELSE
		RETURN 28
END
GO