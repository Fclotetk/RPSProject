DELIMITER //
CREATE PROCEDURE insert_points
(IN winner varchar(20),
IN second varchar(20))
BEGIN
  if (SELECT COUNT(*) FROM rps_scores WHERE Name = winner != 0)
  THEN
  
    UPDATE rps_scores set Points =  Points +3 WHERE Name = winner;
    
    ELSE
    
    INSERT INTO rps_scores (Name, Points) VALUES (winner, 3);
    
  END IF;
  
  IF (SELECT COUNT(*) FROM rps_scores WHERE Name = second != 0)
  THEN 
    
    UPDATE rps_scores set Points = Points +1 WHERE Name = second;
    
    ELSE
    
    INSERT INTO rps_scores (Name, Points) VALUES (second, 1);
    
  END IF;
END //
DELIMITER ;