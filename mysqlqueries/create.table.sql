CREATE TABLE IF NOT EXISTS `rps_scores` (
  `Name` varchar(20) COLLATE latin1_spanish_ci NOT NULL,
  `Points` int(11) NOT NULL,
  PRIMARY KEY (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;
