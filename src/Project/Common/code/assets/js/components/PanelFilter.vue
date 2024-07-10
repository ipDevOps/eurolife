<template>
  <fragment v-if="!filter.isCheckbox">
    <div class="filter__item" v-for="prop in filter.props">      
      <input type="checkbox" :id="`filter-prop-${prop.id}`">
      <label :for="`filter-prop-${prop.id}`" @click="checkValue(prop.id)">{{ prop.value }}</label>
    </div>
  </fragment>
  <fragment v-else>
    <div class="filter__item">      
      <input type="checkbox" :id="`filter-prop-${filter.id}`" />
      <label :for="`filter-prop-${filter.id}`" @click="checkValue(filter.id)">{{ filter.title }}</label>
    </div>
  </fragment>
</template>

<script> 
  export default {
    props: {
      checked: {
        type: Array
      },
      filter: {
        type: Object,
        required: true
      }
    },
    model: {
      prop: 'checked',
      event: 'input'
    },
    methods: {
      checkValue(value) {          
        if (this.checked.includes(value)) {
          this.checked.splice(this.checked.indexOf(value), 1)
        } else {
          this.checked.push(value)
        }

        //this.tableHeightEqualizer();
        //this.$emit('apply');
      }
    }
  }
</script>