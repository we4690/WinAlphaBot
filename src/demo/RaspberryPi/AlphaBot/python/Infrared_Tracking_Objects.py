import RPi.GPIO as GPIO
import time
from AlphaBot import AlphaBot
import smbus

Ab = AlphaBot()

DR = 16
DL = 19

Address = 0x48
A0 = 0x40
A1 = 0x41
bus = smbus.SMBus(1)

GPIO.setmode(GPIO.BCM)
GPIO.setwarnings(False)
GPIO.setup(DR,GPIO.IN,GPIO.PUD_UP)
GPIO.setup(DL,GPIO.IN,GPIO.PUD_UP)

Ab.stop()
try:
	while True:
		bus.write_byte(Address,A0)
		Right_Value = bus.read_byte(Address)
		bus.write_byte(Address,A1)
		Left_Value = bus.read_byte(Address)
		DR_status = GPIO.input(DR)
		DL_status = GPIO.input(DL)
		if((DL_status == 0) and (DR_status == 0)):
			if(Right_Value > 80) and (Left_Value > 80):
				Ab.forward()
			else:
				Ab.stop()
			print("forward")
		elif((DL_status == 1) and (DR_status == 0)):
			Ab.right()
			print("right")
		elif((DL_status == 0) and (DR_status == 1)):
			Ab.left()
			print("left")
		else:
			Ab.stop()
			print("stop")

except KeyboardInterrupt:
	GPIO.cleanup();

