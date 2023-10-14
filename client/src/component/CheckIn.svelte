<script lang="ts">
	import { page } from '$app/stores';
	import { getToastStore, type ToastSettings } from '@skeletonlabs/skeleton';

	const toastStore = getToastStore();

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
		if (response.ok) {
			const t: ToastSettings = {
				message: 'Check-In Successful',
				background: 'variant-filled-success'
			};
			toastStore.trigger(t);
		}
	}
</script>

<button class="btn variant-filled-primary" on:click={handleCheckin}> Check-In </button>
