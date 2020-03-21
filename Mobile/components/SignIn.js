
import React from "react";

import { StyleSheet, Text, View,TextInput,Button } from 'react-native';
function SignIn() {
  const [username, setUsername] = React.useState('');
  const [password, setPassword] = React.useState('');

  const signIn=async ()=>{
    
  }

  return (
    <View>
      <TextInput
        placeholder="Username"
        value={username}
        onChangeText={setUsername}
      />
      <TextInput
        placeholder="Password"
        value={password}
        onChangeText={setPassword}
        secureTextEntry
      />
      <Button title="Sign in" onPress={() => signIn({ username, password })} />
    </View>
  );
}

export default SignIn