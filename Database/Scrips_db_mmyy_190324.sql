Create Database DB_TRUONG_HOSP_V01
Go

Use DB_TRUONG_HOSP_V01
Go

--Create schema mmyymmyy;
--BEGIN CREATE TABLE MMYY----
--BEGIN CREATE EMR-----------
--Create table mmyymmyy.EMR_register
--(
--idlink CHAR(36) primary key not null,
--patid CHAR(36) not null,
--patcode CHAR(10) not null,
--objectcode int,
--objectname NVARCHAR(255),
--hospincode CHAR(20),
--regdate DateTime,
--hospnumberin CHAR(10),
--medexalcode CHAR(10),
--medexalname nvarchar(255),
--doccode NVARCHAR(255),
--addressfull NVARCHAR(max),
--phonenumber NVARCHAR(10),
--done int,
--ispatnew bit,
--pattype int,
--formcode int,
--placeIntrocode CHAR(5),
--placetransfercode CHAR(5),

--note nvarchar(500),
--attributes text,
--datalog text,
--mmyy CHAR(4) not null,
--yyyy CHAR(4) not null,

--siterf  int,
--active int,
--usercr nvarchar(150),
--timecr DateTime,
--userup nvarchar(150),
--timeup DateTime,
--computer nvarchar(150),
--mac nvarchar(150),
--)	
--Go
--CREATE INDEX default_index
--ON mmyymmyy.EMR_register(idlink,patcode)
--Go

Create table mmyymmyy.EMR_registerhi
(
idlinehi CHAR(36) primary key not null,
idlink CHAR(36) not null,
patid CHAR(36) not null,
patcode CHAR(10) not null,
exemptions NVARCHAR(255),
nohi varchar(15),
ratehi INT,
ratepay INT,
rateother INT,
level INT,
reason INT,
minpay decimal(10),
maxpay decimal(10),
salary decimal(10),
isusing bit,
files text,
filename NVARCHAR(255),
approved bit,
typerouteexamid INT,
havepapertransfer bit,

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
CREATE INDEX default_index
ON mmyymmyy.EMR_registerhi(idlink,patcode)
Go

Create table mmyymmyy.EMR_outclinic
(
idline CHAR(36)primary key not null,
idlink CHAR(36) not null,
patid CHAR(36) not null,
patcode CHAR(10) not null,
objectcode int,
objectname NVARCHAR(255),
hospincode CHAR(20),
archivenumber CHAR(10),
hospnumberin CHAR(10),
meditypecode int,
medicode int,
docexamcode CHAR(10),
docexamname NVARCHAR(255),
medexahcode CHAR(10),
medexahname NVARCHAR(255),
medexalcode CHAR(10),
medexalname NVARCHAR(255),
servicecode CHAR(10),
servicename NVARCHAR(255),
examdate DateTime,
examdatefinish  DateTime,
dayofhi INT,
advice NVARCHAR(255),
treatmentcode int,
slovetatuscode int,
dischargestatuscode int,
treatmentresultcode int,
medistatuscode int,
statuscode int,
icd10maincode CHAR(6),
icd10mainname NVARCHAR(255),
icd10extracode CHAR(6),
icd10extraname NVARCHAR(255),
examinationdetail  text,
circuit Decimal(4),
heat Decimal(4),
pressure NVARCHAR(10),
breathing NVARCHAR(10),
height Decimal(4),
weight Decimal(4),
spo2 NVARCHAR(10),
reason NVARCHAR(10),
prehistoric NVARCHAR(255),
allergy NVARCHAR(255),
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
ON mmyymmyy.EMR_outclinic(mmyy,yyyy,idline,idlink, patcode,examdate)
Go

Create table mmyymmyy.EMR_serviceorder
(
idline CHAR(36)primary key not null,
idlink CHAR(36) not null,
patid CHAR(36) not null,
patcode CHAR(10) not null,

mediid CHAR(36),
departid CHAR(36),
happeid CHAR(36),
typepatcode int,
placordercode int,
medexahcode int,
medexalcode int,
docordercode CHAR(10),
dateorder Datetime,
icdorder nvarchar(250),

groupcode CHAR(10),
typecode CHAR(10),
groupprintcode CHAR(10),

pricelistcode int,
servicecode CHAR(10),
servicename nvarchar(250),
servicenameeng nvarchar(250),
servicenamehi nvarchar(250),

unitcode CHAR(10),
qty Decimal(24),
price Decimal(24),
priceovertime Decimal(24),
priceforeign Decimal(24),
pricehi Decimal(24),
difference Decimal(24),
total Decimal(24),

reghiid CHAR(36),
ratehi int,
serpayrate int,
ratepay int,
rateother int,
ishi int,
removehi bit,
isnoresult bit,
ispackage bit,
isfree bit,
times int,
sameteam bit,
sort int,
paid int,
done int,
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
ON mmyymmyy.EMR_serviceorder(mmyy,yyyy,idline,idlink, patcode,medexahcode,medexalcode,timecr)
Go

Create table mmyymmyy.EMR_drugorder
(
idline CHAR(36)primary key not null,
idlink CHAR(36) not null,
patid CHAR(36) not null,
patcode CHAR(10) not null,
mediid CHAR(36),
departid CHAR(36),
happeid CHAR(36),

typepatcode int,
placordercode int,
medexahcode int,
medexalcode int,
docordercode CHAR(10),
dateorder Datetime,
dateapprove Datetime,
icdorder nvarchar(250),

groupcode CHAR(10),
typecode CHAR(10),
groupprintcode CHAR(10),
routecode CHAR(10),
unitusecode CHAR(10),
storecode CHAR(10),

biddinghid CHAR(36),
biddinglid CHAR(36),
unitcode CHAR(10),
drugcode CHAR(10),
drugname nvarchar(250),

stractiveingre nvarchar(500),
multiactiveingre bit,
usage nvarchar(250),

qtymor CHAR(3),
qtydin CHAR(3),
qtyaft CHAR(3),
qtynig CHAR(3),
qtyday CHAR(3),
qty Decimal(24),

price Decimal(24),
total Decimal(24),

isconsumable int,
typedrug int,
typeexport int,

reghiid CHAR(36),
ratehi int,
serpayrate int,
ratepay int,
rateother int,
ishi int,
sort int,
paid int,
done int,
approve int,
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
ON mmyymmyy.EMR_drugorder(mmyy,yyyy,idline,idlink, patcode,medexahcode,medexalcode,timecr)
Go

Create table mmyymmyy.EMR_medicalrecord
(
idline CHAR(36)primary key not null,
idlink CHAR(36) not null,
patid CHAR(36) not null,
patcode CHAR(10) not null,

departid char(36),
happeid CHAR(36),
typeincode int,
meditypecode int,
medicode int,
objectcode int,

hospincode CHAR(20),
archivenumber CHAR(10),
hospnumberin CHAR(10),
hospnumbertran CHAR(10),

datehospin Datetime,
dochospin CHAR(10),
datehospout Datetime,
dochospout CHAR(10),
treatmentcode int,
slovetatuscode int,
dischargestatuscode int,
treatmentresultcode int,

placeintrocode int,
placeintroname int,
hostrantypecode CHAR(5),
hostranincode CHAR(5),
hostraninname NVARCHAR(255),
hostranoutcode CHAR(5),
hostranoutname NVARCHAR(255),
medistatuscode int,
filestatuscode int,
treatmentday int,
reexamdate Datetime,

icdin text,
icdout text,
dayofhi NVARCHAR(255),
instruct NVARCHAR(255),
gpb bit,
img binary,
exareason NVARCHAR(255),
medireasoncancel NVARCHAR(255),

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
ON mmyymmyy.EMR_medicalrecord(mmyy,yyyy,idline,idlink, patcode,timecr)
Go
Create table mmyymmyy.EMR_happenning
(
idline CHAR(36)primary key not null,
idlink CHAR(36) not null,
patid CHAR(36) not null,
patcode CHAR(10) not null,
mediid CHAR(36),
tranid CHAR(36),
hiid CHAR(36),

datecreate Datetime,
content NVARCHAR(500),
doccode CHAR(10),
treamentcontent NVARCHAR(500),
takecareofcontent NVARCHAR(MAX),
nursingperform CHAR(10),
monitor NVARCHAR(500),
executeorder NVARCHAR(MAX),
diet NVARCHAR(500),

circui CHAR(20),
blomin int,
blomax int,
heartb int,
temper Decimal(4),
weight Decimal(4),
spo2 Decimal(4),
height Decimal (4),
bmi  Decimal(4),
bmistr CHAR(10),
specialistcode int, 
specialist text,

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
ON mmyymmyy.EMR_happenning(mmyy,yyyy,idline,idlink, patcode,timecr)
Go

Create table mmyymmyy.EMR_departtranfer
(
idline CHAR(36) primary key,
idlink CHAR(36) not null,
patid CHAR(36) not null,
patcode CHAR(10) not null,
mediid CHAR(36) not null,

tranid CHAR(36),

trandate Datetime,
recedate Datetime,

medexahtrancode CHAR(3),
medexaltrancode CHAR(6),

medexahrececode CHAR(3),
medexalrececode CHAR(6),

docincode CHAR(10),
docoutcode CHAR(10),

icdtranin text,
icdtranout text,

transtatuscode int,
roomid CHAR(36),
roomcode CHAR(10),
roomname NVARCHAR(255),

bedid CHAR(36),
bedcode CHAR(10),
bedname NVARCHAR(255),
statuscode int,

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
mac varchar(150),
)	
Go
CREATE INDEX default_index
ON mmyymmyy.EMR_departtranfer(mmyy,yyyy,idline,patcode,timecr)
Go

--END CREATE EMR--------------------------------------------------------------


--BEGIN CREATE PAY------------------------------------------------------------

Create table mmyymmyy.PAY_paymenth
(
idline CHAR(36) primary key not null,
idlink CHAR(36) not null,
patid CHAR(36) not null,
patcode CHAR(10) not null,
mediid CHAR(36),

idreturn CHAR(36),
symbol CHAR(10),
receiptnum CHAR(10),
userpay CHAR(50),
datepay Datetime,
taxcode CHAR(10),
namebuyer nvarchar(250),
comaddr nvarchar(250),
objectcode int,

typepatcode int,
typepaycode int,
typereceiptcode int,
statuspaycode int,

votes CHAR(20),
ratehi int,
total Decimal(24),
totalhi Decimal(24),
totalpatcopay Decimal(24),
totalpatpay Decimal(24),
totalpatpatcopay Decimal(24),
totalpatpaid Decimal(24),
totaldiscount Decimal(24),
totalvocher Decimal(24),
totalsourcepayothercosts Decimal(24),
totalsourcepayattach Decimal(24),
totalvat Decimal(24),
totaladvance Decimal(24),
totalpathavepay Decimal(24),

istransfer bit,
totaltransfer Decimal(24),
totalcash Decimal(24),
totalpattake Decimal(24),
totalpatrefund Decimal(24),

istranferaccounting bit,
reason nvarchar(500),
discountcode int,

discountname nvarchar(500),
vouchername nvarchar(500),
othercostsname nvarchar(500),
attachname nvarchar(500),

requestadvanceid CHAR(36),
medexahrequestcode int,
medexalrequestcode int,

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
ON mmyymmyy.PAY_paymenth(mmyy,yyyy,idline,votes,idlink, patcode,timecr)
Go

Create table mmyymmyy.PAY_paymentl
(
idline CHAR(36)primary key not null,
idlink CHAR(36) not null,
patid CHAR(36) not null,
patcode CHAR(10) not null,
mediid CHAR(36),

userpay CHAR(50),
datepay Datetime,
idh CHAR(36)not null,
pricelistcode int,
ishi int,
ratehi int,
ratepay int,
serpayrate int,

servicecode CHAR(10) not null,
servicename nvarchar(250),
unitcode CHAR(10) not null,

qty Decimal(24),
price Decimal(24),
priceovertime Decimal(24),
priceforeign Decimal(24),
pricehi Decimal(24),
difference Decimal(24),
amount Decimal(24),
amounthi Decimal(24),
amountpatpay Decimal(24),
amountpatcopay Decimal(24),
amountpatpatcopay Decimal(24),

amountpatpaid Decimal(24),
amountdiscount Decimal(24),
amountsourcepayattach Decimal(24),
amountpathavepay Decimal(24),

discount Decimal(24),
sourcepayattach Decimal(24),
vatrate int,
vat Decimal(24),
amountvat Decimal(24),
discoutype int,
discourate int,
discountname nvarchar(500),

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
CREATE  INDEX default_index
ON mmyymmyy.PAY_paymentl(mmyy,yyyy,idh)
Go
--END CREATE PAY----------------------------------------------------------------------




--BEGIN CREATE PHA------------------------------------------------------------
Create table mmyymmyy.PHA_invoiceinput
(
idline CHAR(36)primary key not null,
form CHAR(30),
serial CHAR(30),
no CHAR(30),
date Datetime,
voucher CHAR(30),
voucherdate Datetime,
suppliercode CHAR(20),
isinvoice bit,
vat int,
vatamount Decimal(24),
discountamount Decimal(24),
discountrate int,
totalamount Decimal(24),
reallyamount Decimal(24),

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
ON mmyymmyy.PHA_invoiceinput(mmyy,yyyy,idline, no,timecr)
Go

Create table mmyymmyy.PHA_storeimporth
(
idline CHAR(36)primary key not null,
code CHAR(30),
name NVARCHAR(255),
sliptypecode int,
actioncode int,
statuscode int,
storecode int,

datecreate datetime,
usercreate char(20),
dateapprove datetime,
userapprove char(20),

invoiceid CHAR(36),
invoicetempid CHAR(36),
invoicedate Datetime,

numdeliverycode CHAR(30),
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
ON mmyymmyy.PHA_storeimporth(mmyy,yyyy,idline,datecreate,sliptypecode,statuscode)
Go

Create table mmyymmyy.PHA_storeimportl
(
idline CHAR(36)primary key not null,
followid CHAR(36),
idh CHAR(36),
lotnumber  CHAR(20),
expirydate Datetime,
ofmanudate Datetime,
bidcontractid CHAR(36),
sort int,
invoiceqty Decimal(24),
convertqty Decimal(24),
total Decimal(24),
vatrate int,
vatamount Decimal(24),
discounttypecode int,
discountcash Decimal(24),
discountrate int,
isdiscount bit,
purchaseformcode int,

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
ON mmyymmyy.PHA_storeimportl(mmyy,yyyy,idline,idh)
Go

Create table mmyymmyy.PHA_flstoreimport
(
idline CHAR(36)primary key not null,
slipid CHAR(36),
slipcode CHAR(30),
sliptypecode int,
status int,
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
ON mmyymmyy.PHA_flstoreimport(mmyy,yyyy,idline,slipid)
Go

Create table mmyymmyy.PHA_storeexporth
(
idline CHAR(36)primary key not null,
code CHAR(30),
name NVARCHAR(255),
sliptypecode int,
actioncode int,
statuscode int,
datecreate datetime,
usercreate char(10),
dateapprove datetime,
userapprove char(10),

storeexpcode int,
storeimpcode int,
status int,
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
ON mmyymmyy.PHA_storeexporth(mmyy,yyyy,idline,datecreate,sliptypecode,statuscode)
Go

Create table mmyymmyy.PHA_storeexportl
(
idline CHAR(36)primary key not null,
idh CHAR(36),
followid CHAR(36),
lotnumber  CHAR(20),
expirydate Datetime,
ofmanudate Datetime,
qtyreq int,
qtyapp int,
price Decimal(24),

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
ON mmyymmyy.PHA_storeexportl(mmyy,yyyy,idline,idh)
Go

Create table mmyymmyy.PHA_flstoreexport
(
idline CHAR(36)primary key not null,
slipcode CHAR(30),
sliptypecode int,
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
ON mmyymmyy.PHA_flstoreexport(mmyy,yyyy,idline)
Go


Create table mmyymmyy.PHA_prescriptionh
(
idline CHAR(36) primary key not null,
code CHAR(30),
name NVARCHAR(255),
pattype int,
typecode int,
statuscode int,

patid CHAR(36),
patcode CHAR(14),
idlink CHAR(30),
mediid CHAR(36),

datecreate Datetime,
usercreate CHAR(10),
dateapprove Datetime,
userapprove CHAR(10),
datepass Datetime,
userpass CHAR(10),

isfinish bit,
dateout Datetime,
icdcode VARCHAR(100),
icdname NVARCHAR(500),

nohi VARCHAR(20),
medexacode CHAR(10),
medexaname NVARCHAR(255),
doccode CHAR(10),
docname NVARCHAR(255),
total Decimal(24),
patpay Decimal(24),
payhi Decimal(24),

reason NVARCHAR(255),
objectcode int,
pricelistcode int,

ratepay int,
rateother int,
idlinehi CHAR(36),
votes CHAR(20),

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
ON mmyymmyy.PHA_prescriptionh(mmyy,yyyy,idline,datecreate,pattype,typecode,statuscode)
Go

Create table mmyymmyy.PHA_prescriptionl
(
idline CHAR(36)primary key not null,
idh CHAR(36),
codeh CHAR(20),
storecode CHAR(20),
followid CHAR(36),
lotnumber  CHAR(20),
expirydate Datetime,
ofmanudate Datetime,
qtyreq int,
qtyapp int,
price Decimal(24),
vatrate int,
vat Decimal(24),
statuscode int,
ishi bit,
biddinghidline char(36),
biddinglidline char(36),
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
ON mmyymmyy.PHA_prescriptionl(mmyy,yyyy,idline,idh)
Go

Create table mmyymmyy.PHA_inventoryh
(
idline CHAR(36) primary key not null,
storecode int,
drugcode CHAR(10),
qtyt Decimal(24),
qtyimp Decimal(24),
qtyexp Decimal(24),
qtyrep Decimal(24),
qtymi Decimal(24),

lotnumber  CHAR(20),
expirydate Datetime,
ofmanudate Datetime,

price Decimal(24),
amount Decimal(24),

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
ON mmyymmyy.PHA_inventoryh(mmyy,yyyy,storecode)
Go

Create table mmyymmyy.PHA_inventoryl
(


idline CHAR(36)primary key not null,
storecode int,
drugcode CHAR(10),

qtyt Decimal(24),
qtyimp Decimal(24),
qtyexp Decimal(24),
qtyrep Decimal(24),
qtymi Decimal(24),
followid CHAR(36),
lotnumber  CHAR(20),
expirydate Datetime,
ofmanudate Datetime,
price Decimal(24),
amount Decimal(24),

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
ON mmyymmyy.PHA_inventoryl(mmyy,yyyy,storecode)
Go

Create table mmyymmyy.PHA_inventorytransaction
(
idline CHAR(36) primary key not null,
followid CHAR(36),
typestatuscode int,
statuscode int,
storecode int,
drugcode CHAR(10),

qtyt Decimal(24),
qtyimp Decimal(24),
qtyexp Decimal(24),
qtyrep Decimal(24),
qtymi Decimal(24),

lotnumber  CHAR(20),
expirydate Datetime,
ofmanudate Datetime,
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
ON mmyymmyy.PHA_inventorytransaction(mmyy,yyyy,idline,storecode)
Go

Create table mmyymmyy.PHA_fltemp
(
idline CHAR(36) primary key not null,
followid CHAR(36),
idh CHAR(36),
codeh CHAR(30),
storecode int,
drugcode CHAR(10),
qtyrep Decimal(24),
qtyapp Decimal(24),
note nvarchar(500),
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
ON mmyymmyy.PHA_fltemp(mmyy,yyyy,idline,idh,codeh)
Go

--END CREATE PAY------------------------------------------------------------

--SYS----------------------------------------

Create table SYS_module
(
id int primary key not null,
code varchar(50),
name Nvarchar(max),
path Nvarchar(max),
icon Nvarchar(max),
note nvarchar(500),
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
ON SYS_module(id)
Go

Create table SYS_menu
(
id int primary key not null,
modulecode varchar(50),
code varchar(50),
name Nvarchar(max),
path Nvarchar(max),
icon Nvarchar(max),
path Nvarchar(max),
component Nvarchar(max),
layout Nvarchar(max),
modulepath Nvarchar(max),
note nvarchar(500),
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
ON SYS_menu(modulecode)
Go

Create table SYS_noseriline
(
id int primary key not null,
code varchar(50),
name Nvarchar(250),
lastnum int,
prefix varchar(10),
surfix varchar(10),
dateused DateTime,
yearused char(4),
typereset varchar(10),
typechar varchar(10),
numreset int
step int,
valueinit int
lennum varchar(20),
descrp nvarchar(150),
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
ON SYS_noseriline(code)
Go



insert into SYS_module (id,code,name,path,icon,note,siterf,active,usercr,timecr,userup,timeup,computer,mac)
values(1,'TIEPNHAN','Tiếp nhận','EMR','MonetizationOnRoundedIcon','',1,1,'truongnp',GETDATE(),'truongnp',GETDATE(),'truongnp','');

insert into SYS_menu (id,modulecode,code,name,path,icon,component,layout,modulepath,note,siterf,active,usercr,timecr,userup,timeup,computer,mac)
values(1,'TIEPNHAN','DANGKY','Đăng ký','/registercomponent','MonetizationOnRoundedIcon','Registercomponent','/admin','/emr','',1,1,'truongnp',GETDATE(),'truongnp',GETDATE(),'truongnp','');
