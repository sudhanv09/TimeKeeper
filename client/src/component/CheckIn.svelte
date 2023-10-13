<script lang="ts">
	import { page } from '$app/stores';
	export let active: boolean;

	const id = $page.params.slug;
	const currTime = new Date().toISOString();
	async function handleCheckin() {
		const response = await fetch('http://localhost:5145/staff/checkin', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify({ id, currTime })
		});
	}
</script>

{#if active}
	<button class="btn variant-filled-primary disabled:opacity-50 disabled:cursor-not-allowed" on:click={handleCheckin}> Check-In </button>
{:else}
	<button class="btn variant-filled-primary" on:click={handleCheckin}> Check-In </button>
{/if}
