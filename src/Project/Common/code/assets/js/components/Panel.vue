<template>
    <div>
      <panel-filters v-if="hasFilters" :filters="panel.filters"></panel-filters>

      <template v-for="category in panel.categories">

        <div v-if="!category.isMain" class="program-expander" :key="`category-${category.id}`">
          <div v-if="category.title" class="program-heading">
            <h2>
              {{ category.title }}
            </h2>
          </div>
          <panel-grid :category="category" :items="panel.items"></panel-grid>
        </div>

        <panel-grid v-else :key="`category-${category.id}`" :category="category" :items="panel.items"></panel-grid>

      </template>
    </div>
</template>

<script>
  import PanelFilters from "./PanelFilters";
  import PanelGrid from './PanelGrid';

  export default {
    props: {
      panel: {
        type: Object,
        required: true
      }
    },
    data: () => ({
      appliedFilters: []
    }),
    computed: {
      hasFilters() {
        return this.panel.filters.items && this.panel.filters.items.length > 0
      }
    },
    components: {
      PanelGrid,
      PanelFilters
    }
  }
</script>