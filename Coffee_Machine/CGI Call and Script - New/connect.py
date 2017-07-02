import commands
import serial
import logging
import sys 
logging.basicConfig(level=logging.DEBUG)
logger = logging.getLogger(__name__)

#file handler for logs
handler = logging.FileHandler('Logging\connect.log')
handler.setLevel(logging.INFO)

# create a logging format
formatter = logging.Formatter('%(asctime)s - %(module)s - %(levelname)s - %(message)s')
handler.setFormatter(formatter)
logger.addHandler(handler)

seqNumber = 0 
COFFEE_BAUD_RATE = 115200

## Important ##
# - Make sure format of RPi is little endian 
# - When run on Pi -  use serial.Serial('/dev/ttyS0',115200, timeout=None)


def Setup():
	logger.disabled = False
	global seqNumber
	seqNumber = 0

def MakeProducts(port,qtyCoffee,qtyEspresso):
	global seqNumber
	for i in range(0,qtyCoffee):
		if(i ==0 and qtyEspresso ==0):
			telegram = commands.DoCoffeeLeftTelegram(seqNum)
		elif(i == 1 and qtyEspresso == 0):
			telegram = commands.DoCoffeeRightTelegram(seqNum)
		elif(i == 0 and qtyEspresso == 1):
			telegram = commands.DoCoffeeLeftTelegram(seqNum)
		logger.info("Start script")
		logger.info("Checking coffee machine status...")
		newSeqNumber = commands.WaitTillReady(port,seqNumber)
		seqNumber = newSeqNumber
		logger.info("Making a coffee ...")
		commands.DoCommand(port,seqNumber,telegram)
		seqNumber += 1

	for j in range(0,qtyEspresso):
		if(j ==0 and qtyCoffee ==0):
			telegram = commands.DoCoffeeRightTelegram(seqNum)
		elif(j == 1 and qtyCoffee == 0):
			telegram = commands.DoCoffeeLeftTelegram(seqNum)
		elif(j == 0 and qtyCoffee == 1):
			telegram = commands.DoCoffeeRightTelegram(seqNum)
		logger.info("Start script")
		logger.info("Checking coffee machine status...")
		newSeqNumber = commands.WaitTillReady(port,seqNumber)
		seqNumber = newSeqNumber
		logger.info("Making an espresso ...")
		commands.DoCommand(port,seqNumber,telegram)
		seqNumber += 1

def OpenThePort():
	while True:
		try:
			port = InstantiatePort()
			break
		except serial.serialutil.SerialException as e:
			if("FileNotFoundError" in str(e)):
				logger.error("No serial connected detected")
				input("Serial port is not connected to anything..  \
				please connect the port and press any key to try again...")
			elif("PermissionError" in str(e)):
				logger.error("Serial port is being used by another application")
				input("Serial port is being used by another application..please close the application and press any key to try again..")
	return port
def CloseThePort(port):
	port.close()
	print("script executed successfully, press any key to exit...")

def InstantiatePort():
	# When using on PC
	#port = serial.Serial('COM7',115200,timeout=None)
	# When using on raspberry with USB/Serial connection
	port = serial.Serial('/dev/ttyUSB0',COFFEE_BAUD_RATE,timeout=None)

	return port
############# Execute as script ###############
if __name__ == "__main__":
	port = InstantiatePort()
	MakeProducts(port,sys.argv[1],sys.argv[2])
