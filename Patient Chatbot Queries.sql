CREATE TABLE PatientMonitors(
monitors_no int primary key,
measurment varchar(50),
touchscreen tinyint,
category varchar(50),
portablity_1 varchar(50),
feature_1 varchar(50),
size_1 varchar(50),
feature_2 varchar(50),
feature_3 varchar(50),
portablity_2 tinyint,
ante_intrapartum varchar(50),
display_mode varchar(50),
weights varchar(50),
feature_4 varchar(50),
invasive_bp tinyint,
co2_measurment tinyint,
nbp_measurment tinyint,
speed varchar(50),
storage_size varchar(50)
)


/*//Update string null to NULL*/

Update ChatbotTable$ SET touchscreen=NULL where touchscreen='null';
Update ChatbotTable$ SET category=NULL where category='null';
Update ChatbotTable$ SET portablity_true=NULL where portablity_true='null';
Update ChatbotTable$ SET feature_true=NULL where feature_true='null';
Update ChatbotTable$ SET size_true=NULL where size_true='null';
Update ChatbotTable$ SET feature_2=NULL where feature_2='null';
Update ChatbotTable$ SET touchscreen=NULL where touchscreen='null';
Update ChatbotTable$ SET feature_3=NULL where feature_3='null';
Update ChatbotTable$ SET portablity_2=NULL where portablity_2='null';
Update ChatbotTable$ SET [ante/intrapartum]=NULL where [ante/intrapartum]='null';
Update ChatbotTable$ SET display_mode=NULL where display_mode='null';
Update ChatbotTable$ SET weights=NULL where weights='null';
Update ChatbotTable$ SET invasive_bp=NULL where invasive_bp='null';
Update ChatbotTable$ SET co2_measurment=NULL where co2_measurment='null';
Update ChatbotTable$ SET nbp_measurment=NULL where nbp_measurment='null';
Update ChatbotTable$ SET storage_size=NULL where storage_size='null';
Update ChatbotTable$ SET speed=NULL where speed='null';
Update ChatbotTable$ SET feature_4=NULL where feature_4='null';