/****** Object:  StoredProcedure [dbo].[SP_GetPromociones]    Script Date: 1/7/2019 17:02:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SP_GetPromociones] @filterPlace varchar(20), @filterUser varchar(20)    
as    
begin    
 declare @tableName1 varchar(50) = 'Promociones';   
 declare @tableName2 varchar(50) = 'Lugares';
 declare @tableName3 varchar(50) = 'Usuarios'; 
           
       declare @sql nvarchar(max) = N'select *     
                from '+@tableName1+' as p  
				join '+@tableName2+' as l on l.idlugar = p.idlugar
				join '+@tableName3+' as u on u.idUsuario = p.idUsuario
                where l.nombre like ''%' + @filterPlace + '%''
				and u.email = ''%' + @filterUser + '%''
				order by p.idPromocion';    
  
    EXECUTE sp_executesql @sql;    
end     