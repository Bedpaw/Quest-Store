<template>
  <div>
    <input v-model="valueIn">
    <button
    @click="getData">
      Wyślij
    </button>
    <p v-for="(data,index) in response.dataSets[0].series['0:0:0:0:0'].observations" :key="index">
      {{data[0]}}
    </p>
    <div>
      {{metaData()}}
    </div>
  </div>
</template>


<script>

export default {
  name: 'test',
  data() {
    return {
      entryPoint: 'https://sdw-wsrest.ecb.europa.eu/service/data',
      valueIn: 'USD',
      response: {
        dataSets: [
          {
            series: {
              "0:0:0:0:0": {
                observations: {

                }
              }
            }
          }
        ]
      }
    }
  },
  methods: {
    getData() {
      fetch(this.entryPoint + '/EXR/D.' + this.valueIn  +'.EUR.SP00.A?startPeriod=2020-09-28&endPeriod=2020-10-07',
          {
            method: 'GET',
            headers: {
              'Accept': 'application/vnd.sdmx.data+json;version=1.0.0-wd'

            }
          })
          .then(response => response.json())
          .then(data => {
            console.log(data)
            this.response = data
          })
          .catch(e => console.log(e))
    },
    metaData(){
      fetch( 'https://sdw-wsrest.ecb.europa.eu/service/datastructure/ECB/ECB_EXR1',
        {
          method: 'GET',
          headers: {
          }
        })
        .then(response => response.text())
        .then(data => {
          console.log(data)
        })
        .catch(e => console.log(e))
    },

    }

}
</script>
