myChart = null;

const getOrCreateLegendList = (chart, id) => {
  const legendContainer = document.getElementById(id);
  let listContainer = legendContainer.querySelector('ul');

  if (!listContainer) {
    listContainer = document.createElement('ul');
    //listContainer.style.display = 'flex';
    //listContainer.style.flexDirection = 'row';
    listContainer.style.margin = 0;
    listContainer.style.padding = 0;
    listContainer.className = 'list-group';

    legendContainer.appendChild(listContainer);
  }

  return listContainer;
};

const htmlLegendPlugin = {
  id: 'htmlLegend',
  afterUpdate(chart, args, options) {
    const ul = getOrCreateLegendList(chart, options.containerID);

    // Remove old legend items
    while (ul.firstChild) {
      ul.firstChild.remove();
    }

    // Reuse the built-in legendItems generator
    const items = chart.options.plugins.legend.labels.generateLabels(chart);

    items.forEach(item => {
      const li = document.createElement('li');
      li.className = 'list-group-item';
      li.style.alignItems = 'center';
      li.style.cursor = 'pointer';
      li.style.display = 'flex';
      li.style.flexDirection = 'row';
      li.style.marginLeft = '10px';

      li.onclick = () => {
        const { type } = chart.config;
        if (type === 'pie' || type === 'doughnut') {
          // Pie and doughnut charts only have a single dataset and visibility is per item
          chart.toggleDataVisibility(item.index);
        } else {
          chart.setDatasetVisibility(item.datasetIndex, !chart.isDatasetVisible(item.datasetIndex));
        }
        chart.update();
      };

      // Color box
      const boxSpan = document.createElement('span');
      boxSpan.style.background = item.fillStyle;
      boxSpan.style.borderColor = item.strokeStyle;
      boxSpan.style.borderWidth = item.lineWidth + 'px';
      boxSpan.style.display = 'inline-block';
      boxSpan.style.flexShrink = 0;
      boxSpan.style.height = '20px';
      boxSpan.style.marginRight = '10px';
      boxSpan.style.width = '20px';

      // Text
      const textContainer = document.createElement('p');
      textContainer.style.color = item.fontColor;
      textContainer.style.margin = 0;
      textContainer.style.padding = 0;
      textContainer.style.textDecoration = item.hidden ? 'line-through' : '';

      const text = document.createTextNode(item.text);
      textContainer.appendChild(text);

      li.appendChild(boxSpan);
      li.appendChild(textContainer);
      ul.appendChild(li);
    });
  }
};

window.owGraph = {
  clear: function () {
    myChart = null;
  },

  show: function (type, labels, dataSeries, optionsType, min, max) {
    var datasets = dataSeries.map(p => this.getDataSeriesSettings(p));
    var options = this.generateOptions(optionsType, min, max);
    var plugins = this.generatePlugins(optionsType);
    if (myChart) {
      myChart.destroy();
    }
    myChart = new Chart(
      document.getElementById('myChart'),
      { type, data: { labels, datasets }, options, plugins }
    );
  },

  getDataSeriesSettings: function (series) {
    return {
      label: series.label,
      data: series.data,
      borderColor: series.color,
      backgroundColor: series.color,
      pointBackgroundColor: series.color,
      pointBorderColor: series.color,
      pointHoverBackgroundColor: series.color,
      pointHoverBorderColor: series.color,
      fill: false,
      cubicInterpolationMode: 'monotone',
      borderWidth: 3,
      pointRadius: 5,
      lineTension: 0.4
    }
  },

  generatePlugins: function (type) {
    if (type === 'Mistakes' || type === 'Performance' || type === 'PerformanceHistogram' || type === 'Time' || type === 'Pack' || type === 'Position') {
      return [htmlLegendPlugin];
    }

    return [];
  },

  generateOptions: function (type, min, max) {
    const options = {
      responsive: true,
      maintainAspectRatio: false,
      legend: {
        position: 'top',
        labels: {
          fontSize: 16,
          fontFamily: 'Roboto Condensed',
          padding: 16
        }
      },
      title: {
        display: false
      },
      tooltips: {
        mode: 'point',
        callbacks: {}
      },
      scales:
      {
        xAxes: [{
          display: true,
          scaleLabel:
          {
            display: true
          }
        }],
        yAxes: [
          {
            display: true,
            scaleLabel: {
              display: true,
              labelString: 'Minutes'
            },
            ticks: {
              stepSize: 60
            },
          }
        ]
      }
    };

    var _this = this;

    if (type === 'Time') {
      options.scales.yAxes[0].ticks.suggestedMax = 0;
      options.scales.yAxes[0].ticks.suggestedMin = -180;
      options.scales.yAxes[0].ticks.stepSize = 60;
      options.plugins = {
        htmlLegend: {
          // ID of the container to put the legend in
          containerID: 'legend-container',
        },
        legend: {
          display: false
        },
        tooltip: {
          callbacks: {
            label: function (context) {
              return (context.dataset.label || '') + ' ' + _this.getMinSec(context.raw);
            }
          }
        }
      };
      options.scales = {
        y: {
          ticks: {
            callback: function (val, index) {
              return _this.getMinSec(val);
            }
          }
        }
      };
    } else if (type === 'Pack') {
      options.scales.yAxes[0].ticks.suggestedMax = max;
      options.scales.yAxes[0].ticks.suggestedMin = min;
      options.scales.yAxes[0].ticks.stepSize = 600;
      options.plugins = {
        htmlLegend: {
          // ID of the container to put the legend in
          containerID: 'legend-container',
        },
        legend: {
          display: false
        },
        tooltip: {
          callbacks: {
            label: function (context) {
              return (context.dataset.label || '') + " " + _this.getHourMinSec(context.raw);
            }
          }
        }
      };
      options.scales = {
        y: {
          ticks: {
            callback: function (val, index) {
              return _this.getHourMin(val);
            }
          },
          title: {
            display: true,
            text: 'Time of day'
          }
        }
      };
    } else if (type === 'Position') {
      options.plugins = {
        htmlLegend: {
          // ID of the container to put the legend in
          containerID: 'legend-container',
        },
        legend: {
          display: false
        }
      };
      options.scales.yAxes[0].ticks.max = max; // runners.length;
      options.scales.yAxes[0].ticks.min = 1;
      options.scales.yAxes[0].ticks.stepSize = 1;
      options.scales = {
        y: {
          title: {
            display: true,
            text: 'Position'
          }
        }
      };
    } else if (type === 'Performance') {
      options.plugins = {
        htmlLegend: {
          // ID of the container to put the legend in
          containerID: 'legend-container',
        },
        legend: {
          display: false
        }
      };
      options.scales.yAxes[0].ticks.suggestedMax = 200;
      options.scales.yAxes[0].ticks.suggestedMin = 0;
      options.scales.yAxes[0].ticks.stepSize = 5;
      options.scales = {
        y: {
          title: {
            display: true,
            text: 'Performance Index'
          }
        }
      };
    } else if (type === 'PerformanceHistogram') {
      options.plugins = {
        htmlLegend: {
          // ID of the container to put the legend in
          containerID: 'legend-container',
        },
        legend: {
          display: false
        }
      };
      options.scales.yAxes[0].ticks.max = max; // (runners || [])[0].splits.length / 2;
      options.scales.yAxes[0].ticks.min = 0;
      options.scales.yAxes[0].ticks.stepSize = 1;
      options.scales = {
        y: {
          title: {
            display: true,
            text: 'Occurences'
          }
        }
      };
    } else if (type === 'Mistakes') {
      options.plugins = {
        htmlLegend: {
          // ID of the container to put the legend in
          containerID: 'legend-container',
        },
        legend: {
          display: false
        },
        tooltip: {
          callbacks: {
            label: function (context) {
              return (context.dataset.label || '') + ' ' + _this.getMinSec(context.raw);
            }
          }
        }
      };
      options.scales = {
        y: {
          ticks: {
            callback: function (val, index) {
              return _this.getMinSec(val);
            }
          }
        }
      };
    } else if (type === 'Mistakes2') {
      options.plugins = {
        htmlLegend: {
          // ID of the container to put the legend in
          containerID: 'legend-container',
        },
        legend: {
          display: false
        },
        tooltip: {
          callbacks: {
            label: function (context) {
              return (context.dataset.label || '') + ' ' + context.raw + '%';
            }
          }
        }
      };
      options.scales.yAxes[0].ticks.max = 100;
      options.scales.yAxes[0].ticks.min = 0;
    }

    return options;
  },

  to2Digits: function (input) {
    return ('00' + input.toFixed(0).toString()).slice(-2);
  },

  getHourMin(input) {
    let value = Math.abs(input);
    const hourMod = value % 3600;
    const hourVal = ((value - hourMod) / 3600);
    const hour = hourVal.toFixed(0);
    value -= (hourVal * 3600);
    const minMod = value % 60;
    const min = ((value - minMod) / 60);

    return hour + ':' + this.to2Digits(min);
  },

  getHourMinSec(input) {
    let value = Math.abs(input);

    const hourMod = value % 3600;
    const hourVal = ((value - hourMod) / 3600);
    const hour = hourVal.toFixed(0);
    value -= (hourVal * 3600);
    const minMod = value % 60;
    const min = ((value - minMod) / 60);

    return hour + ':' + this.to2Digits(min) + ':' + this.to2Digits(minMod);
  },

  getMinSec(input) {
    let value = Math.abs(input);
    const mod = value % 60;
    const min = ((value - mod) / 60);
    return this.to2Digits(min) + ':' + this.to2Digits(mod);
  }
};