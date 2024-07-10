<template>
  <div v-if="identifier == active">
    <slot></slot>
  </div>
</template>

<script>
  import { EventBus } from '../EventBus';
  export default {
    props: {
      identifier: {
        type: Number,
        required: true
      }
    },
    data: () => ({
      active: 0
    }),
    methods: {
      changeVisibility(panel) {
        this.active = panel;
      }
    },
    created() {
      EventBus.$on('panelChanged', panel => this.changeVisibility(panel));
    }
  }
</script>