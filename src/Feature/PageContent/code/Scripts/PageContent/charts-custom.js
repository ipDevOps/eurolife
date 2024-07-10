const items = document.querySelectorAll(".pie-chart");

if (items) {
  for (let i = 0; i < items.length; i++) {

    const item = items[i];
    var legendID = item.dataset.legendid;

    var labelsFromAttribute = JSON.parse(item.dataset.labels);
    var colorsFromAttribute = JSON.parse(item.dataset.colors);
    var dataFromAttribute = JSON.parse(item.dataset.data);

    var myPieChart = new Chart(item, {
      type: 'pie',
      data: {
        labels: labelsFromAttribute,
        datasets: [{
          backgroundColor: colorsFromAttribute,
          data: dataFromAttribute
        }]
      },
      options: {
        elements: {
          arc: {
            borderWidth: 0
          }
        },
        legend: {
          display: false,
          position: 'right'
        },
        legendCallback: function (chart) {
          var text = [];
          text.push('<ul>');
          var ds = chart.data.datasets[0];

          for (var i = 0; i < ds.data.length; i++) {
            text.push('<li>');
            text.push('<span class="chart-legend__color" style="background-color:' + ds.backgroundColor[i] + '">' + '</span>' + ds.data[i] + '%' + '<span class="chart-legend__label">' + chart.data.labels[i] + '</span>');
            text.push('</li>');
          }
          text.push('</ul>');
          return text.join("");
        }
      }
    });
    document.getElementById(legendID).innerHTML = myPieChart.generateLegend();
  }
}


//toggle less/more
let toggler = document.getElementById('charts-toggle');
if (toggler) {
  toggler.addEventListener('click', function (e) {
    e.preventDefault();


    const barsToToggle = document.querySelectorAll(".chart-card__bar-wrap");    
    if (barsToToggle) {
      for (let k = 0; k < barsToToggle.length; k++) {
        const barToToggle = barsToToggle[k];
        barToToggle.classList.toggle('visible');
      }

      initBars();
    }

    document.getElementById('charts-toggle__off').classList.toggle('hidden');
    document.getElementById('charts-toggle__on').classList.toggle('hidden');
    

  });
}


function initBars() {
  //single bar charts
  const baritems = document.querySelectorAll(".bar-chart");
  if (baritems) {
    for (let j = 0; j < baritems.length; j++) {
      const baritem = baritems[j];
      if (!baritem.classList.contains('inited')) {
        baritem.classList.add('inited');

        var colorFromAttribute = JSON.parse(baritem.dataset.color);
        var valueFromAttribute = JSON.parse(baritem.dataset.value);
        var max = 100;

        var bar_chart = new Chart(baritem, {
          type: 'horizontalBar',
          data: {
            labels: [],
            datasets: [{
              data: valueFromAttribute,
              backgroundColor: colorFromAttribute
            }, {
              data: [max - valueFromAttribute],
              backgroundColor: "#EEEEEE",
            },]
          },
          options: {
            legend: {
              display: false
            },
            tooltips: {
              enabled: false
            },
            scales: {
              xAxes: [{
                display: false,
                stacked: true
              }],
              yAxes: [{
                display: false,
                stacked: true
              }],
            }
          }
        });

      }

    }
  }


}


//tooltip on click

const toolHandler = document.querySelectorAll('.js-tool');
if (toolHandler != null) {
  for (const tool of toolHandler) {
    tool.addEventListener('click', _ => {
      tool.classList.toggle('tool--active');

    });
  }
}