import React from "react";

import { FontAwesome } from "@expo/vector-icons";
import { Input } from "react-native-elements";
import { TextWithIcon } from "./textWithIcon";
import { StyleSheet, Text, View, TextInput, Button } from "react-native";
import * as SecureStore from "expo-secure-store";
function SignIn({navigation}) {
  const [username, setUsername] = React.useState("");
  const [password, setPassword] = React.useState("");
  const [token,setToken]=React.useState("")

  const signIn = async () => {
    try{
      const response=await fetch('https://localhost:5001/api/driveraccount/auth ', {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          email: username,
          password: password,
        }),
      });
      myToken=response.headers.get('Authorization')
      if(myToken){
        setToken(myToken)
        SecureStore.setItemAsync("userToken",myToken);
        alert(token)
        navigation.navigate('Home',{token:token});
      }
    }catch(e){
      console.log(e);
      
    }
  };

  return (
    <View style={styles.container}>
      <View style={styles.margin}>
        <Input
          containerStyle={{ width: "80%", padding: 20 }}
          inputContainerStyle={{ width: "80%" }}
          leftIconContainerStyle={{margin:5}}
          label="Username"
          placeholder="Username"
          leftIcon={<FontAwesome name="user" size={24} color="black" />}
          onChangeText={e => setUsername(e)}
        />
      </View>
      <View style={styles.margin}>
        <Input
          containerStyle={{ width: "80%", padding: 20 }}
          inputContainerStyle={{ width: "80%" }}
          leftIconContainerStyle={{margin:5}}
          label="Password"
          placeholder="Password"
          leftIcon={<FontAwesome name="key" size={24} color="black" />}
          onChangeText={e => setPassword(e)}
        />
      </View>
      <Button style={{ margin: 20 }} title="Sign in" onPress={signIn} />
    </View>
  );
}

export default SignIn;
const styles = StyleSheet.create({
  container: {
    flex: 1,
    width: "100%",
    alignItems: "center",
    justifyContent: "center"
  },
  input: {
    margin: 10
  },
  text: {
    fontSize: 30,
    color: "white",
    alignItems: "center",
    justifyContent: "center"
  }
});
