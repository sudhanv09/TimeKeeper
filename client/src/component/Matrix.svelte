<script lang="ts">
	import { onMount } from 'svelte';
	import { Chart } from 'chart.js/auto';
	import { data, options, setup } from '$lib/data';
	import 'chartjs-adapter-date-fns';
	import { MatrixController, MatrixElement } from 'chartjs-chart-matrix';
	import type { UserTimings } from '$lib/types';

	export let checkinData: UserTimings[];
	let userData, userOptions = setup(checkinData);

	Chart.register(MatrixController, MatrixElement);

	let portfolio: any;
	const config = {
		type: 'matrix',
		data: data,
		options: options
	} as any;

	onMount(() => {
		const ctx = portfolio.getContext('2d');
		var myChart = new Chart(ctx, config);
	});
</script>

<div class="">
	<canvas bind:this={portfolio} width="1000" height="400" />
</div>
