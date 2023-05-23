// Dust Sensor
#define OUT A2
#define LED A1
// Motor
#define Motor_N 7   
#define Motor_P 6
#define Motor_EN 5
// Buzzer
#define buzzer 2
// RGB
#define RED 8
#define GREEN 9
#define BLUE 10

int Motion = 0;
int Speed = 0;
int setMotion = 0;
int setSpeed = 0;
int DustADC = 0;
float dustDensity = 0;

void setup() {
  // BaudRate Setup
  Serial.begin(115200);

  // Motor Setup
  pinMode(Motor_N, OUTPUT);
  pinMode(Motor_P, OUTPUT);
  pinMode(Motor_EN, OUTPUT);
  digitalWrite(Motor_N, LOW);
  digitalWrite(Motor_P, LOW);
  digitalWrite(Motor_EN, LOW);

  // Dust Sensor Setup
  pinMode(OUT, INPUT);
  pinMode(LED, OUTPUT);

  // Buzzer Setup
  pinMode(buzzer, OUTPUT);

  // RGB Setup
  pinMode(RED, OUTPUT);
  pinMode(GREEN, OUTPUT);
  pinMode(BLUE, OUTPUT);
}

void Motor_CW(int Speed) {
  digitalWrite(Motor_P, HIGH);
  digitalWrite(Motor_N, LOW);
  analogWrite(Motor_EN, Speed);
}

void Motor_CCW(int Speed) {
  digitalWrite(Motor_P, LOW);
  digitalWrite(Motor_N, HIGH);
  analogWrite(Motor_EN, Speed);
}

void Motor_STOP(){
  digitalWrite(Motor_P, LOW);
  digitalWrite(Motor_N, LOW);
  digitalWrite(Motor_EN, LOW);
}

void Motor_Status() {
  Serial.print("#");
  Serial.print(Motion);
  Serial.print(",");

  if (Speed < 10) {
    Serial.print("00");
    Serial.println(Speed);
  }
  else if((Speed >=10) && (Speed < 100)){
    Serial.print("0");
    Serial.println(Speed);
  }
  else Serial.println(Speed);
}

void motorCapture() {
  if(dustDensity > 150) {
    Motor_CW(255);
    Motion = 1;
    Speed = 255;
  }

  else if(dustDensity <= 150 && dustDensity >= 80){
    Motor_CW(180);
    Motion = 1;
    Speed = 180;
  }

  else {
    Motor_STOP();
    Motion = 0;
    Speed = 0;
  }
  Motor_Status();
}

void manualMotorCapture(int _motion, int _speed) {
  switch (_motion){
    case 0:
      _speed=0;
      digitalWrite(Motor_P, LOW);
      digitalWrite(Motor_N, LOW);
      analogWrite(Motor_EN, _speed);
      break;
    case 1:
      digitalWrite(Motor_P, HIGH);
      digitalWrite(Motor_N, LOW);
      analogWrite(Motor_EN, _speed);
      break;
    case 2:
      digitalWrite(Motor_P, LOW);
      digitalWrite(Motor_N, HIGH);
      analogWrite(Motor_EN, _speed);
      break;
    default:
      _speed=0;
      digitalWrite(Motor_P, LOW);
      digitalWrite(Motor_N, LOW);
      analogWrite(Motor_EN, _speed);
      break;
  }
}

void serialEvent() {
  if(Serial.available()){
    String Rxd = Serial.readStringUntil("\n");

    String cmd = Rxd.substring(1, Rxd.length() -1);
    int comma = cmd.indexOf(",");
    setMotion = cmd.substring(0, comma).toInt();
    setSpeed = cmd.substring(comma + 1).toInt();
  }
}

unsigned int SensorRead(void) {
  unsigned int Sensor_data;

  digitalWrite(LED, LOW);
  delayMicroseconds(280);
  Sensor_data = analogRead(OUT);
  delayMicroseconds(40);
  digitalWrite(LED, HIGH);
  delayMicroseconds(9680);
  return Sensor_data;
}

float DustDensity_ugPm3(int RawVal) {
  float Dust = (float) RawVal * (5.0 / 1023.0) / 5.8 - 0.1;
  return Dust * 1000;
}

void printDust(float dustDensity){
  if (dustDensity >= 100){
    Serial.print((float)dustDensity);
  }
  else {
    Serial.print(0);
    Serial.print((float)dustDensity);
  }
}

void buzzerBeep(float dustDensity) {
  unsigned char i;
  if(dustDensity > 80){
    for(int i=300; i<750; i++){ 
      tone(buzzer, i, 500);
    }
    for(int i=750; i>300; i--){
      tone(buzzer, i, 500);
    }
  }
}

// set RGB Color LED
void setColor(int red, int green, int blue) {
  analogWrite(RED, red);
  analogWrite(GREEN, green);
  analogWrite(BLUE, blue);
}

void printLED(float dust) {
  if (dust >= 0 && dust <= 30){
    setColor(0, 255, 0);
  } else if(dust >= 31 && dust <= 80){
      setColor(255, 255, 0);
  } else if(dust >= 81){
      setColor(255, 0, 0);
  }
}

void loop() {
  DustADC = SensorRead();
  dustDensity = DustDensity_ugPm3(DustADC);

  Serial.print("@");
  Serial.print("0,");

  printDust(dustDensity);       // Print DustDensity Data
  buzzerBeep(dustDensity);      // Buzzer Beep by dustDensity Data
  printLED(dustDensity);        // Light LED by dustDensity Data

  if (Serial.available()){
    manualMotorCapture(setMotion, setSpeed);
  }
  else {
    motorCapture();         // Motor rolling
  }
  delay(300);
}

