--Create Database DB_TRUONG_HOSP_V01
--Go

Use DB_TRUONG_HOSP_V01
Go

-----------------------------------BEGIN CREATE TABLE SHARE ---------------------------------------------
Create table dbo.EMR_patient
(
patid CHAR(36) primary key,
patcode CHAR(10) not null,
name NVARCHAR(255),
nameunsiger VARCHAR(50),
birthday CHAR(10),
birthyear CHAR(4),
age INT,
phonenumber INT,
email NVARCHAR(255),
agecode INT,
sexcode INT,
sexname NVARCHAR(10),
obcode INT,
nationcode INT,
nationNatycode INT,
religioncode INT,
village NVARCHAR(255),
citycode CHAR(2),
districtcode CHAR(3),
wardscode CHAR(5),
addresworkplace NVARCHAR(255),
barcode NVARCHAR(255),
relationcode NVARCHAR(255),
ischildren INT,
parentname NVARCHAR(255),
findcontent NVARCHAR(255),

note nvarchar(500),
attributes text,
datalog text,
mmyys nvarCHAR(MAX),
yyyy CHAR(4) not null,

siterf  int  ,
active int,
usercr nvarchar(150),
timecr DateTime,
userup nvarchar(150),
timeup DateTime,
computer nvarchar(150),
mac nvarchar(150),
)	
Go
CREATE INDEX default_index
ON dbo.EMR_patient(patid,patcode)
Go

Create table dbo.EMR_patienthi
(
idline CHAR(36) primary key not null,
nohi VARCHAR(20),
idlink CHAR(36),
patcode CHAR(10),
fromdate DateTime not null,
totate DateTime ,
gland INT,
isYear bit,
img binary,
filePath VARCHAR(300),
isusing bit,
note nvarchar(500),
attributes text,
datalog text,
mmyy CHAR(4) not null,
yyyy CHAR(4) not null,

siterf  int,
active int,
usercr nvarchar(150),
timecr DateTime,
userup nvarchar(150),
timeup DateTime,
computer nvarchar(150),
mac nvarchar(150),
)	
Go
CREATE INDEX default_index
ON dbo.EMR_patienthi(idline,nohi)
Go


Create table dbo.PHA_catestore
(
id int primary key,
code CHAR(20),
name NVARCHAR(255),
typestorecode int,
ishi bit,
statuscode int,

note nvarchar(500),
attributes text,
datalog text,
mmyy CHAR(4) not null,
yyyy CHAR(4) not null,

siterf int,
active int,
usercr nvarchar(150),
timecr DateTime,
userup nvarchar(150),
timeup DateTime,
computer nvarchar(150),
mac nvarchar(150),
)	
Go

Create table dbo.PHA_cfstorebydepart
(
id int primary key,
typestorecode int,
typeexportcode int,
statuscode int,
medexalcode CHAR(10),
storecode CHAR(20),

note nvarchar(500),
attributes text,
datalog text,
mmyy CHAR(4) not null,
yyyy CHAR(4) not null,

siterf int,
active int,
usercr nvarchar(150),
timecr DateTime,
userup nvarchar(150),
timeup DateTime,
computer nvarchar(150),
mac nvarchar(150),
)	
Go


Create table dbo.PHA_cfuserpermission
(
idline CHAR(36)primary key,
username Char(20),
rolepercode int,
lstproccode varchar(max),
lstpercode varchar(max),
lstactioncode varchar(max),

note nvarchar(500),
attributes text,
datalog text,
mmyy CHAR(4) not null,
yyyy CHAR(4) not null,

siterf int,
active int,
usercr nvarchar(150),
timecr DateTime,
userup nvarchar(150),
timeup DateTime,
computer nvarchar(150),
mac nvarchar(150),
)	
Go

Create table dbo.PHA_cfprocess
(
idline CHAR(36) primary key,
code int,
name NVARCHAR(255),
usercode CHAR(20),

note nvarchar(500),
attributes text,
datalog text,
mmyy CHAR(4) not null,
yyyy CHAR(4) not null,

siterf int,
active int,
usercr nvarchar(150),
timecr DateTime,
userup nvarchar(150),
timeup DateTime,
computer nvarchar(150),
mac nvarchar(150),
)	
Go

Create table dbo.PHA_cfpermission
(
idline CHAR(36) primary key,
proccode int,
code int,
name NVARCHAR(255),

note nvarchar(500),
attributes text,
datalog text,
mmyy CHAR(4) not null,
yyyy CHAR(4) not null,

siterf int,
active int,
usercr nvarchar(150),
timecr DateTime,
userup nvarchar(150),
timeup DateTime,
computer nvarchar(150),
mac nvarchar(150),
)	
Go

Create table dbo.PHA_cfaction
(
idline CHAR(36) primary key,
percode int,
code CHAR(20),
name NVARCHAR(255),
note nvarchar(500),
attributes text,
datalog text,
mmyy CHAR(4) not null,
yyyy CHAR(4) not null,

siterf int,
active int,
usercr nvarchar(150),
timecr DateTime,
userup nvarchar(150),
timeup DateTime,
computer nvarchar(150),
mac nvarchar(150),
)	
Go

Create table dbo.PHA_caterolepermission
(
idline CHAR(36) primary key,
code CHAR(20),
name NVARCHAR(255),
note nvarchar(500),
attributes text,
datalog text,
mmyy CHAR(4) not null,
yyyy CHAR(4) not null,

siterf int,
active int,
usercr nvarchar(150),
timecr DateTime,
userup nvarchar(150),
timeup DateTime,
computer nvarchar(150),
mac nvarchar(150),
)	
Go

Create table dbo.PHA_cateprocess
(
idline CHAR(36) primary key,
code CHAR(20),
name NVARCHAR(255),
note nvarchar(500),
attributes text,
datalog text,
mmyy CHAR(4) not null,
yyyy CHAR(4) not null,

siterf int,
active int,
usercr nvarchar(150),
timecr DateTime,
userup nvarchar(150),
timeup DateTime,
computer nvarchar(150),
mac nvarchar(150),
)	
Go

Create table dbo.PHA_catepermission
(
idline CHAR(36) primary key,
code CHAR(20),
name NVARCHAR(255),

note nvarchar(500),
attributes text,
datalog text,
mmyy CHAR(4) not null,
yyyy CHAR(4) not null,

siterf int,
active int,
usercr nvarchar(150),
timecr DateTime,
userup nvarchar(150),
timeup DateTime,
computer nvarchar(150),
mac nvarchar(150),
)	
Go

Create table dbo.PHA_cateaction
(
idline CHAR(36) primary key,
code CHAR(20),
name NVARCHAR(255),
note nvarchar(500),
attributes text,
datalog text,
mmyy CHAR(4) not null,
yyyy CHAR(4) not null,

siterf int,
active int,
usercr nvarchar(150),
timecr DateTime,
userup nvarchar(150),
timeup DateTime,
computer nvarchar(150),
mac nvarchar(150),
)	
Go

Create table dbo.PHA_drugitem
(
idline CHAR(36) primary key,
group40code int,
grouping40code int,
subgroup40code int,
typevencode int,
typegencode int,
typedispensecode int,
code CHAR(30),
name NVARCHAR(500),
typecode int,
typename NVARCHAR(500),
specificatcode int,
unitcode int,
unitusecode int,
routecode int,
sort int,
status int,
regpaper VARCHAR(255),
suppliercode int,
producercode int,
dorigincode int,
ishi bit,
price Decimal(24),
drugpricecode int,

note nvarchar(500),
attributes text,
datalog text,
mmyy CHAR(4) not null,
yyyy CHAR(4) not null,

siterf int,
active int,
usercr nvarchar(150),
timecr DateTime,
userup nvarchar(150),
timeup DateTime,
computer nvarchar(150),
mac nvarchar(150),
)	
Go
CREATE  INDEX default_index
ON dbo.PHA_drugitem(mmyy,yyyy,idline)
Go

Create table dbo.PHA_pricedrugh
(
idline CHAR(36) primary key,
typecode int,
datebegin Datetime,
dateend Datetime,
code int,
name NVARCHAR(500),
sort int,
status int,
ishi bit,

note nvarchar(500),
attributes text,
datalog text,
mmyy CHAR(4) not null,
yyyy CHAR(4) not null,

siterf int,
active int,
usercr nvarchar(150),
timecr DateTime,
userup nvarchar(150),
timeup DateTime,
computer nvarchar(150),
mac nvarchar(150),
)	
Go
CREATE  INDEX default_index
ON dbo.PHA_pricedrugh(mmyy,yyyy,idline)
Go

Create table dbo.PHA_pricedrugbidl
(
idline CHAR(36) primary key,
idh CHAR(36),
stt int,
active_code VARCHAR(50),
active_code_map VARCHAR(255),
active_string VARCHAR(255),
active_string_map VARCHAR(255),
drug_route_code VARCHAR(255),
drug_route_code_map VARCHAR(255),
drug_route_name VARCHAR(255),
drug_route_name_map VARCHAR(255),
drug_content VARCHAR(255),
drug_content_map VARCHAR(255),
item_name VARCHAR(255),
item_name_map VARCHAR(255),
registration_number VARCHAR(255),
registration_number_map VARCHAR(255),
specifications VARCHAR(255),
unit CHAR(10),
unitprice Decimal(24),
payment_unit_price Decimal(24),
quantity int,
hospcode CHAR(20),
manufacturer VARCHAR(255),
country_of_manufacture VARCHAR(255),
contractors VARCHAR(255),
decision VARCHAR(255),
date_of_publication VARCHAR(255),
hosp_item_code CHAR(20),
hosp_item_name VARCHAR(255),
item_type INT,
bid_package INT,
bid_type INT,
bid_group INT,
group_code INT,
group_decision INT ,

note nvarchar(500),
attributes text,
datalog text,
mmyy CHAR(4) not null,
yyyy CHAR(4) not null,

siterf int,
active int,
usercr nvarchar(150),
timecr DateTime,
userup nvarchar(150),
timeup DateTime,
computer nvarchar(150),
mac nvarchar(150),
)	
Go
CREATE  INDEX default_index
ON dbo.PHA_pricedrugbidl(mmyy,yyyy,idline)
Go

Create table dbo.PHA_pricedrugl
(
idline CHAR(36) primary key ,
idh CHAR(36) not null, 
drugcode CHAR(30),
typecalcode int,
price Decimal(24),
vat Decimal(24),
sort int,
status int,

note nvarchar(500),
attributes text,
datalog text,
mmyy CHAR(4) not null,
yyyy CHAR(4) not null,

siterf int ,
active int,
usercr nvarchar(150),
timecr DateTime,
userup nvarchar(150),
timeup DateTime,
computer nvarchar(150),
mac nvarchar(150),
)	
Go
CREATE  INDEX default_index
ON dbo.PHA_pricedrugl(mmyy,yyyy,idh)
Go

Create table PHA_follow
(
idline CHAR(36) primary key,
idh CHAR(36),
idl CHAR(36),
slipinputcode CHAR(30),
inputtypecode int,
pricelistcode int,
drugcode CHAR(10),
specificatcode CHAR(20),
inputdate Datetime,
invoicedate Datetime,
lotnumber  CHAR(20),
ofmanudate Datetime,
expirydate Datetime,
priceunit Decimal(24),
pricecost Decimal(24),
priceold Decimal(24),
vat int,
vatamount Decimal(24),
discountamount Decimal(24),
discountrate int,
totalamount Decimal(24),

note nvarchar(500),
attributes text,
datalog text,
mmyy CHAR(4) not null,
yyyy CHAR(4) not null,

siterf int,
active int,
usercr nvarchar(150),
timecr DateTime,
userup nvarchar(150),
timeup DateTime,
computer nvarchar(150),
mac nvarchar(150),
)	
Go
CREATE  INDEX default_index
ON dbo.PHA_follow(mmyy,yyyy,idline,slipinputcode,inputdate,inputtypecode)
Go

-- CREATE TABLE SYS----

Create table dbo.SYS_config
(
idline CHAR(36) primary key,
code VARCHAR(50),
objcode VARCHAR(50),
objname NVARCHAR(255),
objtype varchar(100),
objlength INT,
objctl VARCHAR(50),
objcate VARCHAR(50),
descrp NVARCHAR(255),
sort INT,
valcon VARCHAR(255),
label NVARCHAR(255),

siterf  int,
active int,
usercr nvarchar(150),
timecr DateTime,
userup nvarchar(150),
timeup DateTime,
computer nvarchar(150),
mac nvarchar(150),
)	
Go
CREATE INDEX default_index
ON dbo.SYS_config(idline,code,timecr)
Go

Create table dbo.SYS_configslipexam
(
idline VARCHAR(50) primary key,
code char(10),
name VARCHAR(50),

objcode1 VARCHAR(50),
objname1 VARCHAR(255),
objvalue1 VARCHAR(255),
objhiden1 VARCHAR(50),

objcode2 VARCHAR(50),
objname2 VARCHAR(255),
objvalue2 VARCHAR(255),
objhiden2 VARCHAR(50),

objcode3 VARCHAR(50),
objname3 VARCHAR(255),
objvalue3 VARCHAR(255),
objhiden3 VARCHAR(50),

objcode4 VARCHAR(50),
objname4 VARCHAR(255),
objvalue4 VARCHAR(255),
objhiden4 VARCHAR(50),

objcode5 VARCHAR(50),
objname5 VARCHAR(255),
objvalue5 VARCHAR(255),
objhiden5 VARCHAR(50),


objcode6 VARCHAR(50),
objname6 VARCHAR(255),
objvalue6 VARCHAR(255),
objhiden6 VARCHAR(50),

objcode7 VARCHAR(50),
objname7 NVARCHAR(255),
objvalue7 VARCHAR(255),
objhiden7 VARCHAR(50),

objcode8 VARCHAR(50),
objname8 NVARCHAR(255),
objvalue8 VARCHAR(255),
objhiden8 VARCHAR(50),

sort INT,
siterf  int ,
active int,
)	
Go
CREATE INDEX default_index
ON dbo.SYS_configslipexam(idline)
Go

Create table dbo.sysschema
(
rowid int IDENTITY(1,1),
id int,
mmyy CHAR(4) not null primary key,
name CHAR(8) not null,
note nvarchar(500),
datalog text,

siterf  int ,
active int,
usercr nvarchar(150),
timecr DateTime,
userup nvarchar(150),
timeup DateTime,
computer nvarchar(150),
mac nvarchar(150),
)	
Go
CREATE INDEX default_index
ON dbo.sysschema(mmyy)
Go

Create table dbo.systable
(
rowid int primary key IDENTITY(1,1),
schemaid int,
mmyy CHAR(4) not null,
code VARCHAR(255) not null,
name NVARCHAR(255),
note nvarchar(500),
attributes text,
datalog text,

siterf  int,
isuser int,
active int,
usercr nvarchar(150),
timecr DateTime,
userup nvarchar(150),
timeup DateTime,
computer nvarchar(150),
mac nvarchar(150),
)	
Go
CREATE INDEX default_index
ON dbo.systable(mmyy)
Go


Select name, 0 * insert dbo.systable from sys.tables where schema_id = 5;

INSERT INTO dbo.systable (schemaid,mmyy,code,siterf,isuser,active,usercr,timecr
) SELECT schema_id,'mmyy' as mmyy, name, '1' as siterf, '1' as isuser, '1' as active, 'truongnp' as usercr, GETDATE() 
from sys.tables where schema_id = 5;

