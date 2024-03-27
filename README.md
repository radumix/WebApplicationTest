Please read the following steps below:

In order to run this application, install the following requirements.

Framework - ASP.Net MVC.
Database - SQL Server.

Copy and paste this script or command to sql server. open sql server management studio.
And Run this script.

Create first database.
Database name should be testDB

Table Script:
-----------------------------------------------------
USE [testDB]
GO

/****** Object:  Table [dbo].[customer_table]    Script Date: 27/03/2024 11:16:43 pm ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[customer_table](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customer_name] [nvarchar](1000) NULL,
	[customer_address] [nvarchar](1000) NULL,
	[date_created] [datetime] NULL,
	[date_updated] [datetime] NULL,
	[customer_email] [nvarchar](1000) NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[customer_table] ADD  CONSTRAINT [DF_customer_table_date_created]  DEFAULT (getdate()) FOR [date_created]
GO

-----------------------------------------------------------------

Stored Procedures:

1. add_customer_sp - stored procedure
------------------------------------------------------------------------------------------

USE [testDB]
GO

/****** Object:  StoredProcedure [dbo].[add_customer_sp]    Script Date: 27/03/2024 11:19:13 pm ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[add_customer_sp]
	@customer_name nvarchar(1000),
	@customer_address nvarchar(1000),
	@customer_email nvarchar(1000)
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	insert into customer_table (customer_name, customer_address, customer_email) values(@customer_name, @customer_address, @customer_email);
END
GO
-------------------------------------------------------------------


2. delete_customer_by_id_sp - stored procedure
--------------------------------------------------------------
USE [testDB]
GO

/****** Object:  StoredProcedure [dbo].[delete_customer_by_id_sp]    Script Date: 27/03/2024 11:23:02 pm ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[delete_customer_by_id_sp] 
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	delete from customer_table where id = @id;
END
GO
----------------------------------------------------------


3. get_customer_by_id_sp - stored procedure
-----------------------------------------------------------------------

USE [testDB]
GO

/****** Object:  StoredProcedure [dbo].[get_customer_by_id_sp]    Script Date: 27/03/2024 11:24:57 pm ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[get_customer_by_id_sp]
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from customer_table where id = @id;
END
GO
------------------------------------------------------------------------------------


4. get_customer_sp - stored procedure
-------------------------------------------------------------------------------

USE [testDB]
GO

/****** Object:  StoredProcedure [dbo].[get_customer_sp]    Script Date: 27/03/2024 11:28:46 pm ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[get_customer_sp] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    select * from customer_table;
END
GO
---------------------------------------------------



5. update_customer_sp - stored procedure
----------------------------------------------------------

USE [testDB]
GO

/****** Object:  StoredProcedure [dbo].[update_customer_sp]    Script Date: 27/03/2024 11:30:23 pm ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[update_customer_sp]
	     
		@id int,
		@customer_name nvarchar(1000),
		@customer_address nvarchar(1000),
		@customer_email nvarchar(1000)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	update customer_table set customer_name = @customer_name, customer_address = @customer_address, date_updated=getdate(), customer_email = @customer_email
	where id=@id;
    
END
GO
------------------------------------------------------------------------


