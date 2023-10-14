<script lang="ts">
	import { data, options } from '$lib/data';
	import { browser } from '$app/environment';
	import { Chart, type ChartItem, TimeScale } from 'chart.js';
	import { MatrixController, MatrixElement } from 'chartjs-chart-matrix';
    import 'chartjs-adapter-date-fns';

	Chart.register(MatrixController, MatrixElement, TimeScale);

	if (browser) {
		const ctx = browser && (document.getElementById('checkin') as ChartItem);

		const chart = new Chart(ctx, {
			type: 'matrix',
			data: data,
			options: options
		} as any);
	}
</script>

<div>
	<canvas id="checkin" />
</div>
