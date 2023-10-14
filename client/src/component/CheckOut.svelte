<script lang="ts">
	import { page } from '$app/stores';
	import { getToastStore, type ToastSettings } from '@skeletonlabs/skeleton';

	const toastStore = getToastStore();

	const id = $page.params.slug;
	const currTime = new Date().toISOString();

	async function handleCheckout() {
		const response = await fetch('http://localhost:5145/staff/checkout', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify({ id, checkoutTime: currTime })
		});
		if (response.ok) {
			const t: ToastSettings = {
				message: 'Check-Out Successful',
				background: 'variant-filled-success'
			};
			toastStore.trigger(t);
		}
	}
</script>

<button class="btn variant-filled-primary" on:click={handleCheckout}> Check-Out </button>
