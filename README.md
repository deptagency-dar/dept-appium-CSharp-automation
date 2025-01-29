# TCGPlayer Automation Tests

This project is an **Appium C#** test automation framework for **Android and iOS** applications. Follow the steps below to set up your environment and run tests.

---

## 📌 Prerequisites

Before running the automation tests, ensure you have the required dependencies installed on your Mac.

### Install Homebrew (If Not Already Installed)

Homebrew is a package manager for macOS.

```bash
/bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)"
```

Verify installation:
```bash
brew -v
```


### Install .NET SDK

Download and install the latest **.NET SDK** from the official website:

```bash
brew install dotnet
```

Verify installation:
```bash
dotnet --version
```

---

###  Install NPM (Node Package Manager)

NPM is required for installing Appium.

```bash
brew install node
```

Verify installation:
```bash
npm -v
```

---


### 4️⃣ Install Xcode (Required for iOS Testing)

Xcode is required to run iOS tests on a simulator or real device.

```bash
xcode-select --install
```

After installation, open Xcode at least once and accept the license agreement:
```bash
sudo xcodebuild -license accept
```

Verify installation:
```bash
xcodebuild -version
```

---

### 5️⃣ Install Android SDK (Required for Android Testing)

If you don’t have **Android Studio**, install it from [Android Developer Tools](https://developer.android.com/studio).

Alternatively, install the **Android Command-line tools**:

```bash
brew install --cask android-sdk
```

Verify installation:
```bash
sdkmanager --list
```

---

### 6️⃣ Set Environment Variables for Android SDK

After installing the Android SDK, you must set **ANDROID_HOME** or **ANDROID_SDK_ROOT** in your system.

#### Add the following to your `~/.zshrc` or `~/.bash_profile`:
```bash
export ANDROID_HOME=$HOME/Library/Android/sdk
export ANDROID_SDK_ROOT=$ANDROID_HOME
export PATH=$PATH:$ANDROID_HOME/emulator:$ANDROID_HOME/tools:$ANDROID_HOME/tools/bin:$ANDROID_HOME/platform-tools
```

Apply the changes:
```bash
source ~/.zshrc   # or source ~/.bash_profile
```

Verify the SDK location:
```bash
echo $ANDROID_HOME
```

---

### 7️⃣ Install Appium

Appium is required for mobile automation testing.

#### Install Appium globally:
```bash
npm install -g appium
```

#### Install the latest beta version of Appium:
```bash
npm install -g appium@next
```

Verify installation:
```bash
appium -v
```

---

### 8️⃣ Install Appium Drivers

Appium requires platform-specific drivers:

#### Install **UIAutomator2** (for Android):
```bash
appium driver install uiautomator2
```

#### Install **XCUITest** (for iOS):
```bash
appium driver install xcuitest
```

Verify installed drivers:
```bash
appium driver list
```

---

## Create Emulators

Use Android Studio and Xcode to create simulator for the corresponding platforms.

Be aware to match the name of the created devices with the value on the .json ConfigFiles.

---

## 🚀 Running the Tests

In order to run the tests, first you need to bring the Appium server up:

```bash
appium
```

And then you can run the tests, setting the desired platform name as environment parameter
```bash
ASPNETCORE_ENVIRONMENT=Android dotnet test
ASPNETCORE_ENVIRONMENT=iOS dotnet test
```

---

## ✅ Useful command for verifying Setup
To confirm everything is installed correctly, run:

```bash
adb devices  # Check if an Android device/emulator is connected
xcrun simctl list  # List available iOS simulators
appium doctor  # Check if all dependencies are met
```

If `appium doctor` reports missing dependencies, follow the suggested fixes.

---
