Introduction
============
使用手機上的重力感測器，將現實的重力數據傳入到Unity AR遊戲中，讓物件受到重力時會顯得更真實。
* 本專案使用 Unity 2018.1.6f1
* 影像辨識使用 Vuforia 7.2.24
  - 專案有使用 Vuforia UserDefinedTargetBuilder Function，需匯入Vuforia Core Samples。
  https://assetstore.unity.com/packages/templates/packs/vuforia-core-samples-99026
  
* 專案測試時一定要在手機上測試，手機上才有重力感測器


About gravity sensor
============

<img src="https://github.com/Yan-Jun/Vuforia_ARGravitySensor/blob/master/Image/Gravity%20Sensor.png" height="300" width="500" />

重力感測器可以提供重力大小的三維向量，可以參考Android Developer 的介紹。
https://developer.android.com/guide/topics/sensors/sensors_motion#sensors-motion-grav

Unity API 中的 Input.gyro.gravity 可以取得重力感測器。
https://docs.unity3d.com/ScriptReference/Gyroscope-gravity.html


Vuforia + Gravity Sensor
============
事前AR環境設定 - 世界中心為裝置攝影機、攝影機X軸旋轉90度
* World Center Mode = DEVICE
* ARCamera Rotation x = 90

首先要將感測器啟動，並取得重力向量。由於感測器的方向軸與Unity不相同，要自己轉換方向。
轉換方式很簡單，當手機螢幕朝上時上方為Z軸，對應到Unity物件上方為Y軸，所以對物件施加重力時轉換方式
為：Vector3(-GravitySensor.x, GravitySensor.z, -GravitySensor.y)

由於重力是對應到Unity物件上，並不是在攝影機上，X軸和Y軸要為負值。
最後再將轉換的向量給物件的Rigidbody velocity就完成了！

```C#

// Enable gravity by gyroscope

Input.gyro.enabled = true;


// Use a gravity sensor and convert vector 

m_gravitySensor = Input.gyro.gravity;
Vector3 TransGravity = new Vector3(-m_gravitySensor.x, m_gravitySensor.z, -m_gravitySensor.y);
m_rigidbody.velocity = TransGravity;
  
```

* 詳細請至 GravitySensor.cs 中查看。
Vuforia_ARGravitySensor/Project/Assets/Scripts/GravitySensor.cs
* 輸出的APK測試檔案
Vuforia_ARGravitySensor/Project/Output/ARGravity.apk


Other information
============
