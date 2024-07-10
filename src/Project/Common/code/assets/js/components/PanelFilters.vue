<template>
  <div class="filter">
    <span class="filter__trigger" @click="show = true">{{ filters.title }}</span>
    <div :class="['filter__results', 'filter__columns--' + columns_length]" v-show="show">

      <div class="filter__results__column" v-for="(filter,i) in propedFilters" :key="`proped-filter-${i}`">
        <div class="filter__results__heading">{{ filter.title }}</div>
        <panel-filter :filter="filter" v-model="selectedFilters"></panel-filter>
      </div>

      <div v-if="unPropedFilters.length > 0" class="filter__results__column">
        <div class="filter__results__heading"></div>
        <panel-filter v-for="(filter,i) in unPropedFilters"
                      :filter="filter"
                      :key="`unordered-filter-${i}`"
                      v-model="selectedFilters"></panel-filter>
      </div>

      <div class="filter__actions">
        <span class="filter__clear js-clear-filters" @click="clear">{{ filters.clearButton }}</span>
        <span class="filter__cancel js-cancel-filters" @click="cancel">{{ filters.cancelButton }}</span>
        <span class="filter__apply js-apply-filters" @click="apply">{{ filters.applyButton }}</span>
      </div>
    </div>
  </div>
</template>

<script>
  import PanelFilter from './PanelFilter';
  import { EventBus } from '../EventBus.js';    

  export default {
    props: {
      filters: {
        type: Object,
        require: false
      }
    },
    data: () => ({
      show: false,
      propedFilters: [],
      unPropedFilters: [],
      selectedFilters: []
    }),
    computed: {
      columns_length: function () {
        return this.unPropedFilters.length + this.propedFilters.length;
      }
    },
    methods: {
      makeFilters() {         
        if (!this.filters.items)
          return;

        this.filters.items.forEach(filter => {
          if (!filter.isCheckbox)
            this.propedFilters.push(filter);
          else
            this.unPropedFilters.push(filter);
        });
      },
      apply() {
        EventBus.$emit("applyFilters", this.selectedFilters);
        this.tableHeightEqualizer();
        const filterResults = document.querySelector(".filter__results");
        filterResults.classList.remove("filter__results--active");
        this.show = false;
      },
      clear() {
        while (this.selectedFilters.length > 0)
          this.selectedFilters.pop();

        $('.filter__item input[type=checkbox]').each(function () {
          $(this).prop("checked", false);
        });
      },
      cancel() {  
        const filterResults = document.querySelector(".filter__results");
        filterResults.classList.remove("filter__results--active");
        this.show = false;
      },
      tableHeightEqualizer() {
        $(".grid-table-cell").attr("style", "");

        setTimeout(() => {
          $(".program-grid").each(function () {
            const grid = $(this);
            const howmany = $(this).find(".program-attributes .grid-table-cell").length;

            //CUT EXPANDED TABLE WIDTH IN CASE OF 2 COLUMNS
            if ($(window).width() >= 1024)
              if ($(grid).hasClass("program-grid-2"))
                $(grid).parent().css({ "width": "800px", "overflow": "hidden" });
              else
                if ($(grid).hasClass("program-grid-1"))
                  $(grid).parent().css({ "width": "520px", "overflow": "hidden" });

            for (let i = 0; i < howmany; i++) {
              let max = 0;

              //FIND THE MAX PER ROW
              $(grid).find(".grid-table-column").each(function () {
                $(this).find(".grid-table-cell").eq(i).each(function () {
                  if ($(this).height() > max)
                    max = $(this).outerHeight();
                });

                //SET FIXED HEIGHT
                setTimeout(() => { $(this).find(".grid-table-cell").eq(i).height(max + "px"); }, 500);
              });
            }
          });
        }, 500);
      }
    },
    mounted() {
      this.makeFilters();
    },
    components: {
      PanelFilter
    }
  }
</script>