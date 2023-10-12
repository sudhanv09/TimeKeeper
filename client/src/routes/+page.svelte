<script>
	const currDate = new Date()
	$: timeNow = currDate.toLocaleTimeString()
</script>

<div class="flex flex-col space-y-10 h-screen justify-center items-center">
	<div class="space-y-4">
		<h1 class="text-5xl">{timeNow}</h1>
		<h1 class="text-center">{currDate.toLocaleDateString("en-US", {weekday: "long"}) + "," + currDate.toLocaleDateString()}</h1>
	</div>
	<div class="space-x-6">
		<a href="/login" class="btn variant-filled" data-sveltekit-preload-data="hover">Login</a>
		<a href="/register" class="btn variant-filled" data-sveltekit-preload-data="hover">Register</a>
	</div>
</div>