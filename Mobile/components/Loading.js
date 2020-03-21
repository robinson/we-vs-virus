import React from 'react';
import { StyleSheet, Text, View, ActivityIndicator } from 'react-native';
 

export default function Loading() {
  return (
    <View style={styles.container}>
        <View style={{ flex:1,alignItems: "center", justifyContent: "center", alignContent: 'center', }}>
          <Text style={styles.text}> JUST A MOMENT!!</Text>
          <Text style={styles.text}> WE ARE TRYING</Text>
          <Text style={styles.text}>TO CONNECT!!</Text>
          <ActivityIndicator size="large" color="white" />
        </View>
      </View>
  );
}

const styles = StyleSheet.create({
    container: {
      flex: 1,
      backgroundColor: "#005FFD"
    },
    text: {
      fontSize: 25,
      color: "white",
      justifyContent:"center",
      alignItems: "center",
      padding: 5
    }
  });