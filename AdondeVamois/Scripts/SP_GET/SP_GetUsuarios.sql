SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SP_GetUsuarios] @filter varchar(20)  
as    
begin    
	 declare @tableNameUS varchar(50) = 'Usuarios'; 
           
     declare @sql nvarchar(max) = N'
				select *     
                from '+@tableNameUS+' as us  				
                where us.email like ''%' + @filter + '%''				
				order by us.idUsuario';    
  
     EXECUTE sp_executesql @sql;    
end   