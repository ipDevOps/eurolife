<template>
  <section id="panel-group" class="center center--1100 programs">
    <h1 class="h4 m-b-16 t-c">{{ panelsGroup.title }}</h1>
    <p class="m-b-48 t-c center center--650">
      {{ panelsGroup.summary }}
    </p>

    <div class="programs__tabs m-b-64 m-t-48">
      <div v-for="(panel, i) in panelsGroup.panels"
           :key="`panel-button-${panel.id}`"
           @click="changeCurrentPanel(i)"
           :class="['programs__tabs__title', {'programs__tabs__title--active': currentPanel == i }]">
      {{ panel.title }}
      </div>
    </div>

    <transition-group name="slide" tag="div" mode="out-in">
      <app-panel v-for="(panel, i) in panelsGroup.panels" 
                 :key="`panel-${panel.id}`" 
                 :panel="panel"
                 v-show="currentPanel == i"></app-panel>
    </transition-group>
  </section>
</template>

<script>
  import { EventBus } from '../EventBus';

  export default {
    props: {
      panelsGroup: {
        type: Object,
        require: true
      }
    },
    data: () => ({
      currentPanel: 0
    }),
    methods: {
      changeCurrentPanel(i) {
        this.currentPanel = i;
        EventBus.$emit("panelChanged", i)
      }
    }
  }
</script>