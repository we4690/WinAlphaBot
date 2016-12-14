/*************************************** 
Waveshare AlphaBot Car Infrared Remote control

CN: www.waveshare.net/wiki/AlphaBot
EN: www.waveshare.com/wiki/AlphaBot
****************************************/
#include <IRremote.h>                       //Include the IRremote library
#include "AlphaBot.h"

#define KEY2 0x00FF18E7                     //Key:2 
#define KEY8 0x00FF4AB5                     //Key:8 
#define KEY4 0x00FF10EF                     //Key:4 
#define KEY6 0x00FF5AA5                     //Key:6 
#define KEY1 0x00ff30CF                     //Key:1 
#define KEY3 0x00FF7A85                     //Key:3 
#define KEY5 0x00FF38C7                     //Key:5
#define SpeedDown 0x00FFE01F                //Key:VOL-
#define SpeedUp 0x00FFA857                  //Key:VOL+
#define ResetSpeed 0x00FF906F               //Key:EQ
#define Repeat 0xFFFFFFFF                   //press and hold the key

int RECV_PIN = 4;                           //Declare the pin 4 as the infrare remote receiver pin   
IRrecv irrecv(RECV_PIN);
decode_results results;                     //Declare a structur
unsigned long PreviousKey;

AlphaBot Car1 = AlphaBot();

void setup()
{
  Car1.SetSpeed(250);
  irrecv.enableIRIn();                     // Start the receiver
}

/*-----( Declare User-written Functions )-----*/
void translateIR()                         // takes action based on IR code received
{
  if(results.value == Repeat)
    results.value = PreviousKey;
  else
    PreviousKey = results.value;
   
    switch(results.value)
    {
      case KEY1: 
       Car1.LeftCircle();
       break;
       
      case KEY2: 
       Car1.Forward();
       break;
       
      case KEY3: 
       Car1.RightCircle();
       break;
       
      case KEY4: 
       Car1.Left();
       break;

      case KEY5: 
       Car1.Brake();
       break;

      case KEY6: 
       Car1.Right();
       break;

      case KEY8: 
       Car1.Backward();
       break; 
    
      default:
       Car1.Brake();
     
    }// End Case
    
    delay(200);
    
} //END translateIR

void loop()
{ 
  if (irrecv.decode(&results))             // have we received an IR signal?
  {
    translateIR(); 
    irrecv.resume();                      // receive the next value
  }else
  {
   Car1.Brake();
  }
}



