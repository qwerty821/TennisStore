

INSERT INTO BRANDS VALUES (SYS_GUID(), 'Tecnifibre');
INSERT INTO BRANDS VALUES (SYS_GUID(), 'Babolat');
INSERT INTO BRANDS VALUES (SYS_GUID(), 'Wilson');
INSERT INTO BRANDS VALUES (SYS_GUID(), 'Head');
INSERT INTO BRANDS VALUES (SYS_GUID(), 'Yonex');


INSERT INTO Rackets VALUES(SYS_GUID(), 'Babolat Pure Aero', (SELECT b_id FROM BRANDS WHERE b_name LIKE 'Babolat' ), 249.99, 'https://www.tennisexpress.com/prodimages/105017-DEFAULT-m.jpg');
INSERT INTO Rackets VALUES(SYS_GUID(), 'Babolat Pure Drive', (SELECT b_id FROM BRANDS WHERE b_name LIKE 'Babolat' ), 269, 'https://www.tennisexpress.com/prodimages/111523-DEFAULT-m.jpg');
INSERT INTO Rackets VALUES(SYS_GUID(), 'Babolat Pure Strike', (SELECT b_id FROM BRANDS WHERE b_name LIKE 'Babolat' ), 279, 'https://www.tennisexpress.com/prodimages/110865-DEFAULT-m.jpg');

INSERT INTO Rackets VALUES(SYS_GUID(), 'Tecnifibre TFight ISO 300', (SELECT b_id FROM BRANDS WHERE b_name LIKE 'Tecnifibre' ), 249, 'https://www.tennisexpress.com/prodimages/107087-DEFAULT-m.jpg');
INSERT INTO Rackets VALUES(SYS_GUID(), 'Tecnifibre TF40', (SELECT b_id FROM BRANDS WHERE b_name LIKE 'Tecnifibre' ), 249, 'https://www.tennisexpress.com/prodimages/100147-DEFAULT-m.jpg');
INSERT INTO Rackets VALUES(SYS_GUID(), 'Tecnifibre TF-X1', (SELECT b_id FROM BRANDS WHERE b_name LIKE 'Tecnifibre' ), 199.99, 'https://www.tennisexpress.com/prodimages/98098-DEFAULT-m.jpg');

INSERT INTO Rackets VALUES(SYS_GUID(), 'Wilson Blade 98', (SELECT b_id FROM BRANDS WHERE b_name LIKE 'Wilson' ), 259, 'https://www.tennisexpress.com/prodimages/111447-DEFAULT-m.jpg');
INSERT INTO Rackets VALUES(SYS_GUID(), 'Wilson Pro Staff 97', (SELECT b_id FROM BRANDS WHERE b_name LIKE 'Wilson' ), 279, 'https://www.tennisexpress.com/prodimages/107326-DEFAULT-m.jpg');
INSERT INTO Rackets VALUES(SYS_GUID(), 'Wilson Pro Staff 97', (SELECT b_id FROM BRANDS WHERE b_name LIKE 'Wilson' ), 279, 'https://www.tennisexpress.com/prodimages/107326-DEFAULT-m.jpg');
INSERT INTO Rackets VALUES(SYS_GUID(), 'Head Speed Pro Legend', (SELECT b_id FROM BRANDS WHERE b_name LIKE 'Head' ), 269, 'https://www.tennisexpress.com/prodimages/112468-DEFAULT-m.jpg');
INSERT INTO Rackets VALUES(SYS_GUID(), 'Head Speed MP Legend', (SELECT b_id FROM BRANDS WHERE b_name LIKE 'Head' ), 259, 'https://www.tennisexpress.com/prodimages/112470-DEFAULT-m.jpg');
INSERT INTO Rackets VALUES(SYS_GUID(), 'Head Speed MP', (SELECT b_id FROM BRANDS WHERE b_name LIKE 'Head' ), 194, 'https://www.tennisexpress.com/prodimages/110802-DEFAULT-m.jpg');
INSERT INTO Rackets VALUES(SYS_GUID(), 'Head Radical MP', (SELECT b_id FROM BRANDS WHERE b_name LIKE 'Head' ), 259, 'https://www.tennisexpress.com/prodimages/111429-DEFAULT-m.jpg');
INSERT INTO Rackets VALUES(SYS_GUID(), 'Head Radical Pro', (SELECT b_id FROM BRANDS WHERE b_name LIKE 'Head' ), 269, 'https://www.tennisexpress.com/prodimages/106968-DEFAULT-m.jpg');
INSERT INTO Rackets VALUES(SYS_GUID(), 'Head Gravity Pro', (SELECT b_id FROM BRANDS WHERE b_name LIKE 'Head' ), 269, 'https://www.tennisexpress.com/prodimages/107967-DEFAULT-m.jpg');
INSERT INTO Rackets VALUES(SYS_GUID(), 'Head Gravity MP', (SELECT b_id FROM BRANDS WHERE b_name LIKE 'Head' ), 259, 'https://www.tennisexpress.com/prodimages/107939-DEFAULT-m.jpg');
INSERT INTO Rackets VALUES(SYS_GUID(), 'Head Extreme MP', (SELECT b_id FROM BRANDS WHERE b_name LIKE 'Head' ), 259, 'https://www.tennisexpress.com/prodimages/105033-DEFAULT-m.jpg');

INSERT INTO Rackets VALUES(SYS_GUID(), 'Yonex Ezone 98', (SELECT b_id FROM BRANDS WHERE b_name LIKE 'Yonex' ), 269, 'https://www.tennisexpress.com/prodimages/110823-DEFAULT-m.jpg');
INSERT INTO Rackets VALUES(SYS_GUID(), 'Yonex Ezone 100', (SELECT b_id FROM BRANDS WHERE b_name LIKE 'Yonex' ), 269, 'https://www.tennisexpress.com/prodimages/110827-DEFAULT-m.jpg');
INSERT INTO Rackets VALUES(SYS_GUID(), 'Yonex Perfect 97', (SELECT b_id FROM BRANDS WHERE b_name LIKE 'Yonex' ), 269, 'https://www.tennisexpress.com/prodimages/109492-DEFAULT-m.jpg');
INSERT INTO Rackets VALUES(SYS_GUID(), 'Yonex VCORE 95', (SELECT b_id FROM BRANDS WHERE b_name LIKE 'Yonex' ), 269, 'https://www.tennisexpress.com/prodimages/106914-DEFAULT-m.jpg');
INSERT INTO Rackets VALUES(SYS_GUID(), 'Yonex Astrel 105', (SELECT b_id FROM BRANDS WHERE b_name LIKE 'Yonex' ), 269, 'https://www.tennisexpress.com/prodimages/110189-DEFAULT-m.jpg');






