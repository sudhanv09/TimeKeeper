<script lang="ts">
	import type { PageData } from './$types';
	import CheckIn from '../../../component/CheckIn.svelte';
	import CheckOut from '../../../component/CheckOut.svelte';
	import { user } from '$lib/store';
	// import Matrix from '../../../component/Matrix.svelte';

	export let data: PageData;	

    const totalSalary = data.userTime.at(-1)?.totalSalary
    const totalHours = data.userTime.at(-1)?.totalHoursWorked.toPrecision(3)
</script>

<div class="h-1/4 flex justify-between p-8">
	<div class="flex flex-row justify-between w-1/3">
		<div class="space-y-16">
			<h1 class="text-semi-bold text-4xl text-center">{$user.name}</h1>
			<div class="space-x-8">
				<CheckIn />
				<CheckOut />
			</div>
		</div>
		
		<div class="space-y-6">
			<h3>User Total Earnings: {totalSalary}</h3>
			<h3>Total Hours Worked: {totalHours}</h3>
		</div>
	</div>
	<!-- <div>
		<Matrix />
	</div> -->
</div>



<div class="m-4 space-y-4">
	<h1 class="font-normal text-2xl">Timings</h1>
	<table class="w-full text-sm text-left text-gray-500 dark:text-white">
		<thead class="text-xs text-white uppercase bg-gray-50 dark:bg-gray-700 dark:text-white">
			<tr>
				<th class="px-6 py-4">Date</th>
				<th class="px-6 py-4">Check-In</th>
				<th class="px-6 py-4">Check-Out</th>
				<th class="px-6 py-4">Hours</th>
				<th class="px-6 py-4">Earnings</th>
			</tr>
		</thead>
		<tbody>
			{#each data.userTime as row, i}
				<tr class="bg-white border-b dark:bg-gray-800 dark:border-gray-700 hover:bg-gray-50 dark:hover:bg-gray-600">
					<td class="px-6 py-4">{new Date(row.checkIn).toLocaleDateString()}</td>
					<td class="px-6 py-4">{row.checkIn}</td>
					<td class="px-6 py-4">{row.checkOut}</td>
					<td class="px-6 py-4">{row.todaysHours.toPrecision(3)}</td>
					<td class="px-6 py-4">{row.todaysEarnings}</td>
				</tr>
			{/each}
		</tbody>
	</table>
</div>
