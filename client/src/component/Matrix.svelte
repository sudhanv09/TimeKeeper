<script lang="ts">
	import { onMount } from 'svelte';
	import { Chart } from 'chart.js/auto';
	import { genData } from '$lib/helpers';
	import 'chartjs-adapter-date-fns';

	import { MatrixController, MatrixElement } from 'chartjs-chart-matrix';
	import type { UserTimings } from '$lib/types';

	export let checkinData: UserTimings[];

	Chart.register(MatrixController, MatrixElement);

	const data = {
		datasets: [
			{
				label: 'Check-In',
				data: genData(checkinData),
				backgroundColor: function (c) {
					const value = c.dataset.data[c.dataIndex].v;			
					const alpha = value * 20 / 60;			
					return `rgba(0, 255, 0, ${alpha})`;
				},
				borderColor: 'green',
				borderRadius: 1,
				borderWidth: 1,
				hoverBackgroundColor: 'rgba(255, 26, 104, 0.2)',
				hoverBorderColor: 'rgba(255, 26, 104, 1)',
				width(c) {
					const a = c.chart.chartArea || {};
					return (a.right - a.left) / 53 - 1;
				},
				height(c) {
					const a = c.chart.chartArea || {};
					return (a.bottom - a.top) / 7 - 1;
				}
			}
		]
	};

	const scales = {
		y: {
			type: 'time',
			offset: true,
			time: {
				unit: 'day',
				round: 'day',
				isoWeekday: 1,
				parser: 'i',
				displayFormats: {
					day: 'iiiiii'
				}
			},
			reverse: true,
			position: 'left',
			ticks: {
				maxRotation: 0,
				autoSkip: true,
				padding: 1,
				font: {
					size: 12
				}
			},
			grid: {
				display: false,
				drawBorder: false,
				tickLength: 0
			}
		},
		x: {
			type: 'time',
			position: 'bottom',
			offset: true,
			time: {
				unit: 'week',
				round: 'week',
				isoWeekday: 1,
				displayFormats: {
					week: 'MMM dd'
				}
			},
			ticks: {
				maxRotation: 0,
				autoSkip: true,
				font: {
					size: 12
				}
			},
			grid: {
				display: false,
				drawBorder: false,
				tickLength: 0
			}
		}
	};

	const options = {
		aspectRatio: 5,
		plugins: {
			legend: false,
			tooltip: {
				callbacks: {
					title() {
						return '';
					},
					label(context) {
						const v = context.dataset.data[context.dataIndex];
						return ['x: ' + v.x, 'y: ' + v.y, 'v: ' + v.v];
					}
				}
			}
		},
		scales: scales,
		layout: {
			padding: {
				top: 10
			}
		}
	};

	let portfolio: any;
	const config = {
		type: 'matrix',
		data: data,
		options: options
	} as any;

	onMount(() => {
		const context = portfolio.getContext('2d');
		var myChart = new Chart(context, config);
	});
</script>

<div class="">
	<canvas bind:this={portfolio} width="1000" height="400" />
</div>
