SET IDENTITY_INSERT Hosts ON;

INSERT INTO dbo.Hosts (Id,FullName,Email,Phone) VALUES
	 (1,N'Palm Beach',N'palm@hotmail.com',N'+1786997766'),
	 (2,N'West Tree',N'westtree@yahoo.es',N'+5354567788'),
	 (3,N'Best',N'best@gmail.com',N'+5544332211');

SET IDENTITY_INSERT dbo.Hosts OFF;

SET IDENTITY_INSERT Properties ON;

INSERT INTO dbo.Properties (Id,Name,Location,PricePerNight,Status,CreatedAt,HostId) VALUES
	 (1,N'Hotel Florida',N'Texas',45.45,1,'2025-10-14 00:50:20.5900000',2),
	 (2,N'Hostal Casa',N'Tampa',100.99,0,'2025-10-14 00:57:35.4600000',2),
	 (3,N'China Town',N'Moron',10.12,0,'2025-10-14 21:29:09.3623000',1),
	 (4,N'Los Angeles',N'Moron',100.56,1,'2025-10-15 13:48:41.1217606',1),
	 (5,N'Habana Libre',N'Moron',100.78,1,'2025-10-15 13:50:20.0478202',1),
	 (6,N'Riviera',N'Moron',200.00,1,'2025-10-15 13:50:53.9384956',2),
	 (7,N'Las Cabras',N'Miami',200.87,1,'2025-10-15 14:39:19.6490416',1),
	 (8,N'Observation',N'Miami',80.85,1,'2025-10-15 14:40:16.4937891',1),
	 (9,N'Heaven',N'Texas',100.00,1,'2025-10-15 14:57:25.3671918',2),
	 (10,N'Paradise',N'Moron',34.55,1,'2025-10-15 14:57:45.9017632',1);
INSERT INTO dbo.Properties  (Id,Name,Location,PricePerNight,Status,CreatedAt,HostId) VALUES
	 (11,N'The Goat',N'Moron',56.44,1,'2025-10-15 14:58:04.5580837',3),
	 (12,N'The Origin',N'Texas',100.00,1,'2025-10-15 15:53:31.2928138',3);

SET IDENTITY_INSERT Properties OFF;

INSERT INTO dbo.DomainEvents (EventType,CreatedAt,PayloadJSON,PropertyId) VALUES
	 (N'CREATED','2025-10-15 16:29:16.5247513',N'{data:[1,2,3]}',1),
	 (N'CREATED','2025-10-15 16:29:39.6019737',N'{data:[1,2,3]}',2),
	 (N'CREATED','2025-10-15 16:29:42.1900762',N'{data:[1,2,3]}',12);


INSERT INTO dbo.Users (Username,Password) VALUES
	 (N'admin',N'$2a$11$QOqXT8lUuk3Gvd3viSBqROsxlSJgPt12pcrcf8pG40GQzSgltS4.O'),
	 (N'anibal',N'$2a$11$Dn0t/x2YLth9tx3YGWFxkeWSI1bjt7P/hhVtZbyuIOZKYGmyPFO9W'),
	 (N'felix',N'$2a$11$ugYUAdpQDa25r6hA5fgsV.ZUUVKEbsY9RkXGlc1X6tEHd3/xi1h9W'),
	 (N'mirtha',N'$2a$11$gXJD8kcy..LTd8o/DlKZqOXnskoCR0zAoOiLF/DZ4I1pGnRdOik/C');
