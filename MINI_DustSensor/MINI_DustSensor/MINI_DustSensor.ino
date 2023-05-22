#define OUT A2
#define LED A1
#define Motor_N 7   
#define Motor_P 6
#define Motor_EN 5

int Motion = 0;
int Speed = 0;
int DustADC = 0;
float dustDensity = 0;
char buf[80];

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

void motorCapture(int motion) {
  switch(motion) {
    case 0: Motor_STOP(); Speed = 0; break;
    case 1: Motor_CW(Speed); break;
    case 2: Motor_CCW(Speed); break;
    default : Motor_STOP(); Speed = 0; break;
  }

  Motor_Status();
}

void serialEvent() {
  if(Serial.available()){
    String Rxd = Serial.readStringUntil("\n");
    String cmd = Rxd.substring(1, Rxd.length() -1);
    int comma = cmd.indexOf(",");
    Motion = cmd.substring(0, comma).toInt();
    Speed = cmd.substring(comma + 1).toInt();

    Serial.println(Motion);
    Serial.println(Speed);
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

void loop() {
  
  DustADC = SensorRead();
  // Serial.print("Dust[ug/m3]:");
  dustDensity = DustDensity_ugPm3(DustADC);
  // Serial.println(dustDensity);

  Serial.print("@");
  Serial.print("0,");
  // Serial.print("D");
  if (dustDensity > 100){
    Serial.print((float)dustDensity);
  }
  else {
    Serial.print(0);
    Serial.print((float)dustDensity);
  }
  // sprintf(buf, "%0f", (float)dustDensity);
  // Serial.print(F("%0f", (float)dustDensity));
  // Serial.print((float)dustDensity);
  // Serial.print("\n");

  // Motor rolling
  motorCapture(Motion);

  delay(500);
}

