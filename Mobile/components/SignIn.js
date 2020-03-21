
import React from "react";

import { StyleSheet, Text, View,TextInput,Button } from 'react-native';
import { TouchableOpacity } from "react-native-gesture-handler";
function SignIn() {
  const [username, setUsername] = React.useState('');
  const [password, setPassword] = React.useState('');

  const signIn=async ()=>{
    
  }

  return (
    <View style={styles.container}>
      <View style= {styles.titleContainer}>
    <Text style={styles.titleText}>Collectify!</Text>
      </View>
      <View style= {styles.loginFormContainer}>
      <TextInput style = {styles.input}
        placeholder="Username"
        value={username}
        placeholderTextColor={'white'}
        onChangeText={setUsername}
      />
      <TextInput style = {styles.input}
        placeholder="Password"
        value={password}
        placeholderTextColor={'white'}
        onChangeText={setPassword}
        secureTextEntry
      />
      <TouchableOpacity style = {styles.loginButton} onPress={() => signIn({ username, password })} >
        <Text style={styles.loginButtonText}>Login</Text>
      </TouchableOpacity>
      </View>
    </View>
  );
}
const styles = StyleSheet.create({
  container: {
    flex:1, 
    flexDirection:"column"
  },
  titleContainer: {
    flex: 0.5, 
    backgroundColor: 'white', 
    alignItems:'center', 
    justifyContent:'center'
  },
  titleText:{
    color: '#3399ff', 
    fontSize: 32,
    fontWeight: "bold"
  },
  loginFormContainer:{
    flex: 0.5, 
    backgroundColor: '#3399ff',
    padding: 12
  },
  input:{
    padding: 12, 
    color: 'white', 
    fontSize: 16, 
    borderColor: 'white', 
    borderWidth:1, 
    margin: 12
  },
  loginButton:{
    padding: 12, 
    margin: 28, 
    backgroundColor: '#3399ff', 
    alignItems:'center', 
    borderRadius: 12, 
    borderColor:'white', 
    borderWidth: 2
  },
  loginButtonText:{
    color: 'white', 
    fontSize: 16, 
    fontWeight:'bold'},
});


export default SignIn