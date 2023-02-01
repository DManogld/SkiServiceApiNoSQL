SELECT c.Name, c.EMail, c.Phone, c.CreateDate, c.PickupDate,c.Kommentar,p.PriorityName, f.FacilityName, s.StatusName FROM 
dbo.Clients as c

INNER JOIN dbo.Facilities as f
ON f.FacilityID = c.FacilityID 

INNER JOIN dbo.Priorities as p
ON p.PriorityID = c.PriorityID

INNER JOIN dbo.Status as s
ON s.StatusID = c.StatusID
	FOR JSON PATH, INCLUDE_NULL_VALUES

GO