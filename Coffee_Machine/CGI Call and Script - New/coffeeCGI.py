#!/usr/bin/env python
import cgi
import cgitb; cgitb.enable()
import time
import connect 

print ("Content-Type: text/html")
print ("")

arguments = cgi.FieldStorage()
quantityCoffee=0
quantityEspresso=0


port = connect.OpenThePort()
connect.Setup()
if 'coffee' in arguments:
    quantityCoffee=arguments.getvalue('coffee')

if 'espresso' in arguments:
    quantityEspresso=arguments.getvalue('espresso')

connect.MakeProducts(port,quantityCoffee,quantityEspresso)
connect.CloseThePort(port)
print ('Quantity coffee: %s<br>' % quantityCoffee)
print ('Quantity Espresso: %s' % quantityEspresso)
#Here we have to call the funtion for coffee order with parameters
#quantityCoffee and quantityWater
#Just for logs we write down to see wheter the order was correctly recognized
with open('log.txt', 'a') as f:
    f.write('Order successful: %s coffee and %s water at time %s\n' % \
    (quantityCoffee,quantityEspresso,time.strftime("%d.%m.%Y %H:%M:%S")))
