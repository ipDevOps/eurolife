<template>
    <div :class="`program-grid ${panelGridClass} program-grid-${items.length}`">

        <div class="grid-table-column program-attributes">
            <div v-if="category.isMain" class="grid-table-cell"></div>
            <div class="grid-table-cell" v-for="row in category.rows" :key="`panel-row-${row.id}`">
              {{ row.title }}
              <span class="tool" v-if="row.panelrowtooltip">
                <svg xmlns="http://www.w3.org/2000/svg" width="60" height="60" viewBox="0 0 60 60">
                  <path fill="#003B4D" fill-rule="nonzero" d="M30 57C15.088 57 3 44.912 3 30S15.088 3 30 3s27 12.088 27 27-12.088 27-27 27zm0-4.91c12.2 0 22.09-9.89 22.09-22.09S42.2 7.91 30 7.91 7.91 17.8 7.91 30 17.8 52.09 30 52.09zm4.295-33.74c0 1.016-.349 1.884-1.051 2.598-.7.717-1.545 1.075-2.532 1.075-.99 0-1.836-.358-2.545-1.075-.707-.714-1.061-1.582-1.061-2.599 0-1.015.354-1.885 1.061-2.608.707-.722 1.555-1.082 2.545-1.082.987 0 1.832.361 2.532 1.082.702.723 1.051 1.593 1.051 2.608zm-.35 24.209a61.187 61.187 0 0 1-2.525 1.157c-.628.266-1.358.398-2.19.398-1.276 0-2.27-.38-2.978-1.137-.708-.758-1.063-1.72-1.063-2.886 0-.452.027-.916.08-1.389.054-.473.139-1.008.256-1.604l1.319-5.674c.117-.543.216-1.058.296-1.546.08-.483.12-.928.12-1.33 0-.724-.123-1.23-.369-1.515-.246-.285-.714-.43-1.41-.43-.34 0-.69.068-1.048.196-.358.128-.57-1.38-.57-1.38a29.59 29.59 0 0 1 2.479-1.098c.79-.304 1.535-.457 2.24-.457 1.269 0 2.248.372 2.935 1.118.686.746 1.03 1.713 1.03 2.906 0 .246-.023.68-.07 1.301a10.427 10.427 0 0 1-.265 1.711l-1.313 5.653c-.107.454-.204.972-.288 1.556-.086.58-.128 1.024-.128 1.321 0 .751.137 1.263.413 1.536.278.272.756.408 1.436.408.32 0 .682-.07 1.086-.204.403-.136.526 1.389.526 1.389z" />
                </svg>
                <span class="tooltext">{{ row.panelrowtooltip }}</span>
              </span>
            </div>
        </div>

        <div class="grid-table-window">
            <div class="grid-table js-grid-table" id="programs-table" :style="`--programCount:${items.length};`">
                <template v-for="item in items">
                    <panel-column :key="`panel-row-item${item.id}`" :category="category" :item="item"></panel-column>
                </template>
            </div>
        </div>

    </div>
</template>

<script>
    import PanelColumn from "./PanelColumn";

    export default {
        props: {
            category: {
                type: Object,
                required: true
            },
            items: {
                type: Array,
                required: true
            }
        },
        computed: {
            panelGridClass() {
                return !this.category.isMain ? "program-grid--subsection" : "";
            }
        },
        components: {
            PanelColumn
        }
    }
</script>