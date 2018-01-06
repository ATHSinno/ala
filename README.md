# ala
**Instruction to Host My Web Application
 --To Host Web Application IIS (Internet Information System)
Step 1: From Visual Studio, publish your Web application.
Step 2: Copy the published application folder to "C:\intepub\wwwroot" [default] folder.
Step 3: From RUN - > inetmgr -> OK      to Open IIS 
-- The folder will be under Default Web Site
Step 4: We need to convert it to an application, just right click and then Click on "ConvertToApplication"


**Assumption
-The web config file contains key that identifiied the service Url -in case of service url changed just change url from web config file- where App read json from, also the main query string will be included in service Url, main query string and values as below: 

1- scenario=deal-finder
2-page=foo
3-uid=foo
4-productType=Hotel







