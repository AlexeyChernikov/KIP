<?php
function print_tree($level = -1)
{
    $dir = '.';
    $iterator = new RecursiveIteratorIterator(
        new RecursiveDirectoryIterator($dir, RecursiveDirectoryIterator::SKIP_DOTS), 
		RecursiveIteratorIterator::SELF_FIRST
    );
    if ($level > -1) {
        $iterator->setMaxDepth($level);
    }
    foreach ($iterator as $path => $obj) {
        if ($obj->isDir())
		{
            echo $path . '<br>';
        }
		if ($obj->isFile())
		{
            echo $path . '<br>';
        }
    }
}
print_tree();
?>