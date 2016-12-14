# This veENBion uses new-style automatic setup/destroy/mapping
# Need to change /etc/webiopi

# Imports
import webiopi
import RPi.GPIO as GPIO
import time

# -------------------------------------------------- #
# Constants definition                               #
# -------------------------------------------------- #

# Left motor GPIOs
IN1=13 # H-Bridge 1
IN2=12 # H-Bridge 2
ENA=6 # H-Bridge 1,2EN

# Right motor GPIOs
IN3=20 # H-Bridge 3
IN4=21 # H-Bridge 4
ENB=26 # H-Bridge 3,4EN

# Servo GPIOs
S1=27
S2=22
    
# Setup GPIOs
GPIO.setmode(GPIO.BCM)
GPIO.setwarnings(False)
GPIO.setup(ENA, GPIO.OUT)
GPIO.setup(IN1, GPIO.OUT)
GPIO.setup(IN2, GPIO.OUT)
    
GPIO.setup(ENB, GPIO.OUT)
GPIO.setup(IN3, GPIO.OUT)
GPIO.setup(IN4, GPIO.OUT)

GPIO.setup(S1, GPIO.OUT)
GPIO.setup(S2, GPIO.OUT)

# set software PWM 
PENA  = GPIO.PWM(ENA,50)
PENA.start(100)
PENB  = GPIO.PWM(ENB,50)
PENB.start(100)
PS1 = GPIO.PWM(S1,50)
PS1.start(50)
PS2 = GPIO.PWM(S2,50)
PS2.start(50)


# -------------------------------------------------- #
# Macro definition part                              #
# -------------------------------------------------- #
@webiopi.macro
def set_speed(speed):
	PENA.ChangeDutyCycle(float(speed))
	PENB.ChangeDutyCycle(float(speed))

@webiopi.macro
def set_servo1(angle):
	PS1.ChangeDutyCycle(12.5 - 10.0 * float(angle) / 180)

@webiopi.macro
def set_servo2(angle):
	PS2.ChangeDutyCycle(12.5 - 10.0 * float(angle) / 180)

@webiopi.macro
def go_forward():
    GPIO.output(IN1, GPIO.HIGH)
    GPIO.output(IN2, GPIO.LOW)
    GPIO.output(IN3, GPIO.HIGH)
    GPIO.output(IN4, GPIO.LOW)

@webiopi.macro
def go_backward():
    GPIO.output(IN1, GPIO.LOW)
    GPIO.output(IN2, GPIO.HIGH)
    GPIO.output(IN3, GPIO.LOW)
    GPIO.output(IN4, GPIO.HIGH)

@webiopi.macro
def turn_left():
    GPIO.output(IN1, GPIO.LOW)
    GPIO.output(IN2, GPIO.HIGH)
    GPIO.output(IN3, GPIO.HIGH)
    GPIO.output(IN4, GPIO.LOW)
	
@webiopi.macro
def turn_right():
    GPIO.output(IN1, GPIO.HIGH)
    GPIO.output(IN2, GPIO.LOW)
    GPIO.output(IN3, GPIO.LOW)
    GPIO.output(IN4, GPIO.HIGH)

@webiopi.macro
def stop():
    GPIO.output(IN1, GPIO.LOW)
    GPIO.output(IN2, GPIO.LOW)
    GPIO.output(IN3, GPIO.LOW)
    GPIO.output(IN4, GPIO.LOW)
    
# Called by WebIOPi at script loading
def setup():
    # Setup GPIOs
    GPIO.setup(IN1, GPIO.OUT)
    GPIO.setup(IN2, GPIO.OUT)
    GPIO.setup(IN3, GPIO.OUT)
    GPIO.setup(IN4, GPIO.OUT)
    set_servo1(90)
    set_servo2(90)


# Called by WebIOPi at server shutdown
def destroy():
    # Reset GPIO functions

    GPIO.setup(IN1, GPIO.IN)
    GPIO.setup(IN2, GPIO.IN)
    GPIO.setup(IN3, GPIO.IN)
    GPIO.setup(IN4, GPIO.IN)
    GPIO.setup(ENA, GPIO.IN)
    GPIO.setup(ENB, GPIO.IN)
    
