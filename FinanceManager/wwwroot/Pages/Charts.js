google.charts.load('current', { 'packages': ['corechart'] });

export function draw(params) {

    drawChart(params);
}

function drawChart(params) {
    var data = new google.visualization.DataTable();

    data.addColumn('string', 'Category');
    data.addColumn('number', 'Sum');

    for (var i = 0; i < params.length; i++) {
        data.addRow([params[i].category, params[i].sum])
    }

    var chart = new google.visualization.PieChart(document.getElementById('chart_div'));

    var options = {
        title: 'Расходы',
        pieHole: 0.4
    };

    chart.draw(data, options);
}
