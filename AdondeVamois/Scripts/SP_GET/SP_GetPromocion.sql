/****** Object:  StoredProcedure [dbo].[SP_GetPromociones]    Script Date: 9/6/2019 18:09:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_GetPromociones] @filter1 varchar(20), @filter2 varchar(20)    
as    
begin    
 declare @tableName1 varchar(50) = 'Promociones';   
 declare @tableName2 varchar(50) = 'Lugares';
 declare @tableName3 varchar(50) = 'Usuarios'; 
           
       declare @sql nvarchar(max) = N'select *     
                from '+@tableName1+' as p  
				join '+@tableName2+' as l on l.id = p.id
				join '+@tableName3+' as u on u.id = p.id 
                where l.nombre like ''%' + @filter1 + '%''
				and u.email = ''%' + @filter2 + '%''
				order by p.descripcion';    
  
    EXECUTE sp_executesql @sql;    
end   