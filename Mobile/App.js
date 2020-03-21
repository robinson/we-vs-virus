import React from 'react';
import { StyleSheet, Text, View } from 'react-native';

export default function App() {
  return (
    <View style={styles.container}>
      <Text style={styles.text}>Wir kämpfen </Text>
      <Text style={styles.text}> gegen CORONA! </Text>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: 'blue',
    alignItems: 'center',
    justifyContent: 'center'
  },
  text:{
    fontSize:30,
    color:'white',
    alignItems:'center',
    justifyContent:"center" 
  }
});
